using Moo.Entities.ViewModels;
using Moo.Entities.Interfaces;
using System.Web.Mvc;
using Moo.Entities.ViewModels.Game;
using Moo.Entities.DataEntities;
using System.Collections.Generic;
using System.Linq;
using Moo.Entities.Models;

namespace Moo.Controllers
{
    public class GameController : Controller
    {
        public const string USER_GUESS = "Guess";
        public const string OPPONENT_GUESS = "OpponentGuess";
        public const string USER_RESPONSE = "UserResponse";

        private readonly IGameService Service;

        public GameController(IGameService service)
        {
            this.Service = service;
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Route("{number:regex([1-9][0-9]{3})}")]
        public ActionResult New(string number)
        {
            var gameId = Service.InitiateGame(number);
            return RedirectToAction("Guess");
        }

        // GET: Game/Play
        public ActionResult Play()
        {
            var game = Service.GetActiveGame();
            if (game == null)
                return RedirectToAction("New");

            return View(new GameViewModel()
            {
                GameID = game.ID,
                UserNumber = game.UserNumber,
                Rounds = game.UserTurns == null ? 0 : game.UserTurns.ToList().Count(),
                UserTurns = game.UserTurns == null ? new List<Turn>() : game.UserTurns.ToList(),
                OpponentTurns = game.UserTurns == null ? new List<OpponentTurn>() : game.OpponentTurns.ToList(),
                FormAction = "Guess"
            });
        }

        [HttpPost]
        public ActionResult Guess(GameViewModel viewData)
        { 
            var game = Service.GetActiveGame();
            var data = new GuessData()
            {
                GameID = game.ID,
                Guess = viewData.Guess,
                Rounds = game.UserTurns.Count()
            };
            Service.HandleUserGuess(data, out int bulls, out int cows);

            viewData.UserTurns = game.UserTurns.ToList();
            viewData.OpponentTurns = game.OpponentTurns.ToList();
            viewData.UserNumber = game.UserNumber;
            viewData.Bulls = bulls;
            viewData.Cows = cows;
            viewData.FormAction = "OpponentGuess";
            return View("Play", viewData);
        }

        [HttpPost]
        public ActionResult OpponentGuess(GameViewModel viewData)
        {
            var game = Service.GetActiveGame();
            var data = new GuessData()
            {
                GameID = game.ID,
                Rounds = game.OpponentTurns.Count()
            };

            viewData.Guess = Service.HandleOpponentGuess(data);
            viewData.UserTurns = game.UserTurns.ToList();
            viewData.OpponentTurns = game.OpponentTurns.ToList();
            viewData.UserNumber = game.UserNumber;
            viewData.FormAction = "UserResponse";
            return View("Play", viewData);
        }

        [HttpPost]
        public ActionResult UserResponse(GameViewModel viewData)
        {
            var game = Service.GetActiveGame();
            var data = new ResponseData()
            {
                GameID = game.ID,
                Cows = viewData.Cows,
                Bulls = viewData.Bulls,
                Rounds = game.UserTurns.Count(),
                Guess = viewData.Guess
            };
            Service.HandleUserResponse(data);
            viewData.FormAction = "Guess";
            viewData.UserTurns = game.UserTurns.ToList();
            viewData.OpponentTurns = game.OpponentTurns.ToList();
            viewData.UserNumber = game.UserNumber;
            return View("Play", viewData);
        }

        public ActionResult TopPlayers()
        {
            var topPlayers = Service.GetTopPlayers(25);
            var viewModel = new TopPlayersViewModel() { TopPlayers = Service.GetTopPlayers(25) };
            return View(viewModel);
        }
    }
}