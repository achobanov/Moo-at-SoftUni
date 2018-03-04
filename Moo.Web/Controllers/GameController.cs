using Moo.Entities.Interfaces;
using Moo.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Moo.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService Service;

        public GameController(IGameService service)
        {
            this.Service = service;
        }
        // GET: Game/Play
        public ActionResult Play()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Play()
        //{

        //    return View();
        //}

        public ActionResult TopPlayers()
        {
            var topPlayers = Service.GetTopPlayers(25);
            return View(Service.GetTopPlayers(25));
        }
    }
}