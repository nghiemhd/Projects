using Client.Web.Models;
using Client.Web.Framework.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using TestProject.Core.Entities;
using TestProject.Service.ServiceContracts;

namespace Client.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAuthenticationService authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [AllowAnonymous]
        public ActionResult SignIn(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SignIn(SignInViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                bool isValid = authenticationService.ValidateUser(model.Email, model.Password);
                if (isValid)
                {
                    int cookieExpiration;
                    int.TryParse(ConfigurationManager.AppSettings["CookieExpiration"], out cookieExpiration);
                    if (cookieExpiration <= 0)
                    {
                        cookieExpiration = 30;
                    }

                    var authTicket = new FormsAuthenticationTicket(
                        1,
                        model.Email,
                        DateTime.Now,
                        DateTime.Now.AddMinutes(cookieExpiration),
                        model.RememberMe,
                        "");

                    string encrypedTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypedTicket);
                    if (authTicket.IsPersistent)
                    {
                        faCookie.Expires = DateTime.MaxValue;
                    }
                    Response.Cookies.Add(faCookie);

                    //if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    //    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    //{
                    //    return Redirect(returnUrl);
                    //}
                    //else
                    //{
                    //    return RedirectToAction("Index", "Home");
                    //}

                    return Json("true");

                }
                //ModelState.AddModelError("", "Incorrect username and/or password");
            }

            return Json("false");
        }

        [AllowAnonymous]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SignUp(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existedUser = authenticationService.GetUserByUsername(model.Email);
                if (existedUser != null)
                {
                    return Json(new { errors = new List<string> { "This email address already exists." } });
                }

                var user = new User
                {
                    Username = model.Email,
                    Email = model.Email,
                    Password = model.Password,
                    IsActive = true
                };

                authenticationService.RegisterUser(user);
                return SignIn(new SignInViewModel { Email = user.Username, Password = model.Password }, string.Empty);
            }

            var errors = ModelState.GetErrors();

            return Json(new { errors = errors });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("SignIn", "Account");
        }
    }
}