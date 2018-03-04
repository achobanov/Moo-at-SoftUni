using Moo.Entities.Interfaces;
using Moo.Entities.ViewModels;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace Moo.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService service;

        public AccountController(IAccountService service)
        {
            this.service = service;
        }

        // GET: Account  
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string ReturnUrl = "")
        {
            if (User.Identity.IsAuthenticated)
            {
                return Logout();
            }
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginData, string ReturnUrl = "")
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something Wrong : Username or Password invalid ^_^ ");
                return View(loginData);
            }

            var cookie = service.Login(loginData);
            if (cookie == null)
            {
                loginData.Status = false;
                loginData.Message = "Wrong credentials.";
                return View(loginData);
            }
            Response.Cookies.Add(cookie);

            if (Url.IsLocalUrl(ReturnUrl))
                return Redirect(ReturnUrl);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationViewModel registrationData)
        {
            if (!ModelState.IsValid)
            {
                registrationData.Message = "Invalid data!";
                return View(registrationData);
            }

            var registrationSuccess = service.Register(registrationData);
            if (!registrationSuccess)
            {
                registrationData.Status = false;
                registrationData.Message = "Username taken, please chose another.";
                return View(registrationData);
            }

            return RedirectToAction("Login");
        }

        //public ActionResult ActivationAccount(int id)
        //{
        //    var viewModel = new ViewModel();
        //    var activationSuccess = service.ActivateAccount(id);
        //    if (activationSuccess)
        //    {
        //        viewModel.Status = true;
        //        viewModel.Message = "Account succesfully activated!";
        //    }
        //    else
        //    {
        //        viewModel.Status = false;
        //        viewModel.Message = "Something is wrong!";
        //    }
            
        //    return View(viewModel);
        //}

        public ActionResult Logout()
        {
            var cookie = service.Logout();
            Response.Cookies.Add(cookie);
            return RedirectToAction("Login", "Account", null);
        }
    }
}