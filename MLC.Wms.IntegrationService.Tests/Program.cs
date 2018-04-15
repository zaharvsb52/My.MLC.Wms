using System;
using System.ServiceModel;
using MLC.Wms.IntegrationService.Tests.Properties;

namespace MLC.Wms.IntegrationService.Tests
{
    class Program
    {
        //http://sameproblemmorecode.blogspot.ru/2011/10/creating-secure-restfull-wcf-service.html
        static void Main(string[] args)
        {
            string res;
            labelBegin:

            try
            {
                var endpoint = new EndpointAddress(new Uri(Settings.Default.EndPoint));
                var client = new QueueTstServiceClient.QueueTstServiceClient(Settings.Default.EndPointClientConfigName, endpoint);

                Console.WriteLine("========================================");
                Console.WriteLine("WCF test");
                Console.WriteLine("EndPoint: {0}, EndPointClientConfigName: {1}", endpoint.Uri, Settings.Default.EndPointClientConfigName);
                Console.WriteLine("========================================");

                Console.WriteLine("UserName:");
                var keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.Escape)
                    return;
                client.ClientCredentials.UserName.UserName = keyinfo.KeyChar + Console.ReadLine();

                Console.WriteLine("Password:");
                keyinfo = Console.ReadKey();
                if (keyinfo.Key == ConsoleKey.Escape)
                    return;
                client.ClientCredentials.UserName.Password = keyinfo.KeyChar + Console.ReadLine();

                //client.ClientCredentials.UserName.UserName = "111";
                //client.ClientCredentials.UserName.Password = "123456";

                var asyncresult = client.BeginDoWork("Привет!", null, null);
                res = client.EndDoWork(asyncresult);
                Console.WriteLine("wcf service contract 'DoWork' returns: {0}", res);

                //var httpRequestProperty = new HttpRequestMessageProperty();

                //httpRequestProperty.Headers[HttpRequestHeader.Authorization] = "Basic " +
                //    Convert.ToBase64String(Encoding.ASCII.GetBytes(client.ClientCredentials.UserName.UserName + ":" +
                //    client.ClientCredentials.UserName.Password));

                //using (new OperationContextScope(client.InnerChannel))
                //{
                //    OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] =
                //        httpRequestProperty;

                //    var asyncresult = client.BeginDoWork("Привет!", null, null);
                //    res = client.EndDoWork(asyncresult);
                //}

                Console.WriteLine("Exit - esc");
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                    goto labelBegin;
            }
            catch (Exception ex)
            {
                //Unhandled Exception: System.ServiceModel.Security.MessageSecurityException: The HTTP request is unauthorized with client authentication scheme 'Anonymous'.The authentication header received from the server was 'Basic realm="my-server:9090" '. --->System.Net.WebException: The remote server returned an error: (401) Unauthorized.
                //The HTTP request is unauthorized with client authentication scheme 'Basic'.

                Console.WriteLine("---------------------------");
                Console.WriteLine(ex);
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                    goto labelBegin;
            }
        }
    }
}
