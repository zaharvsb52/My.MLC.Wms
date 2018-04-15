using System;
using System.Configuration;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using Microsoft.Practices.ServiceLocation;
using MLC.Wms.Common.Services;

namespace MLC.Wms.Integration
{
    public class UserNameAuthenticator : IHttpModule
    {
        private const string Realm = "MLC";

        public void Init(HttpApplication context)
        {
            // Register evesnt handlers
            context.AuthenticateRequest += OnApplicationAuthenticateRequest;
            context.EndRequest += OnApplicationEndRequest;
        }

        private static bool ValidateUser(string username, string password)
        {
            try
            {
                string userName;
                var authService = ServiceLocator.Current.GetInstance<IAuthService>();
                return authService.Authenticate(username, password, out userName);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool AuthenticateUser(string credentials)
        {
            bool validated;

            try
            {
                var encoding = Encoding.GetEncoding("iso-8859-1");
                credentials = encoding.GetString(Convert.FromBase64String(credentials));

                int separator = credentials.IndexOf(':');
                string name = credentials.Substring(0, separator);
                string password = credentials.Substring(separator + 1);

                validated = ValidateUser(name, password);
            }
            catch (FormatException)
            {
                // Credentials were not formatted correctly.
                validated = false;

            }
            return validated;
        }

        private static void OnApplicationAuthenticateRequest(object sender, EventArgs e)
        {
            var useSecuritySetting = ConfigurationManager.AppSettings["UseCustomAuthentication"];
            bool useSecurity;
            bool.TryParse(useSecuritySetting, out useSecurity);

            var app = (HttpApplication) sender;
            var request = HttpContext.Current.Request;
            var authHeader = request.Headers["Authorization"];
            if (authHeader != null)
            {
                var authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);

                // RFC 2617 sec 1.2, "scheme" name is case-insensitive
                if (authHeaderVal.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase) && authHeaderVal.Parameter != null)
                {
                    if (!AuthenticateUser(authHeaderVal.Parameter) && useSecurity)
                        DenyAccess(app);
                }
            }
            else
            {
                if (useSecurity)
                {
                    app.Response.StatusCode = 401;
                    app.Response.End();
                }
            }
        }

        private static void DenyAccess(HttpApplication app)
        {
            app.Response.StatusCode = 401;
            app.Response.StatusDescription = "Access Denied";

            // Write to response stream as well, to give user visual 
            // indication of error during development
            app.Response.Write("401 Access Denied");

            app.CompleteRequest();
        }

        // If the request was unauthorized, add the WWW-Authenticate header 
        // to the response.
        private static void OnApplicationEndRequest(object sender, EventArgs e)
        {
            var response = HttpContext.Current.Response;
            if (response.StatusCode == 401)
            {
                response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", Realm));
            }
        }

        public void Dispose()
        {
        }
    }
}