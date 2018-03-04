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

        [HttpPost]
        public ActionResult Play(string userAttempt, bool isInitialRound)
        {
            var result = Service.HandleRound(userAttempt, isInitialRound);
            return View(result);
        }
        
        public ActionResult TopPlayers()
        {
            var topPlayers = Service.GetTopPlayers(25);
            var viewModel = new TopPlayersViewModel() { TopPlayers = Service.GetTopPlayers(25) };
            return View(viewModel);
        }
    }
}