using System.Web.Mvc;
using System.Web.Security;
using MLC.Wms.Common.Services;
using MLC.Wms.WebApp.Common;
using WebClient.ExtDirectHandler.Extensions;

namespace MLC.Wms.WebApp.Controllers
{
    public class SecurityController : Controller
    {
        private readonly IAuthService _authService;

        public SecurityController(IAuthService authService)
        {
            _authService = authService;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            string userName;
            if (!_authService.Authenticate(login, password,out userName ))
            {
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = false,
                        errors = new ErrorDescriptor
                        {
                            Title = "Неверное имя пользователя или пароль."
                        }
                    }
                };
            }

            FormsAuthentication.SetAuthCookie(userName, false);

            return new JsonNetResult { Data = new { success = true, userCode = userName } };
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}