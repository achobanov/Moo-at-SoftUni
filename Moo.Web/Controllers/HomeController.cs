using Moo.Entities.Interfaces;
using Moo.Entities.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Moo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService service;

        public HomeController(IHomeService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            return Content(service.Test());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}