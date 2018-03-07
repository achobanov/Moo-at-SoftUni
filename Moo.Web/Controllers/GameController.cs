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
        private const string TEMP_DATA_KEY = "model";

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
            return RedirectToAction("Play");
        }

        // GET: Game/Play
        public ActionResult Play()
        {
            var gameData = TempData[TEMP_DATA_KEY] as GameViewModel;
            if (gameData == null)
                gameData = Service.GetActiveGame(isLoadingFromDb: true);
            if (gameData == null)
                return RedirectToAction("New");

            return View(gameData);
        }

        [HttpPost]
        public ActionResult Guess(GameViewModel viewData)
        { 
            var gameData = Service.GetActiveGame();
            var data = new GuessData()
            {
                GameID = gameData.GameID,
                Rounds = gameData.UserTurns.Count(),
                Guess = viewData.Guess
            };
            Service.HandleUserGuess(data, out int bulls, out int cows);

            gameData.Guess = viewData.Guess;
            gameData.Bulls = bulls;
            gameData.Cows = cows;
            gameData.OpponentNumberSlots = viewData.OpponentNumberSlots;
            gameData.PostFormToAction = "OpponentGuess";
            TempData[TEMP_DATA_KEY] = gameData;
            return RedirectToAction("Play");
        }

        [HttpPost]
        public ActionResult OpponentGuess(GameViewModel viewData)
        {
            var gameData = Service.GetActiveGame();
            var data = new GuessData()
            {
                GameID = gameData.GameID,
                Rounds = gameData.OpponentTurns.Count()
            };

            gameData.Guess = Service.HandleOpponentGuess(data);
            gameData.PostFormToAction = "UserResponse";
            gameData.OpponentNumberSlots = viewData.OpponentNumberSlots;
            gameData.Bulls = 0;
            gameData.Cows = 0;
            TempData[TEMP_DATA_KEY] = gameData;
            return RedirectToAction("Play");
        }

        [HttpPost]
        public ActionResult UserResponse(GameViewModel viewData)
        {
            var gameData = Service.GetActiveGame();
            var data = new ResponseData()
            {
                GameID = gameData.GameID,
                UserTurns = gameData.UserTurns,
                OpponentTurns = gameData.OpponentTurns,
                Cows = viewData.Cows,
                Bulls = viewData.Bulls,
                Guess = viewData.Guess
            };
            Service.HandleUserResponse(data);

            gameData.OpponentNumberSlots = viewData.OpponentNumberSlots;
            gameData.PostFormToAction = "Guess";
            gameData.Guess = "";
            TempData[TEMP_DATA_KEY] = gameData;
            return RedirectToAction("Play");
        }

        public ActionResult TopPlayers()
        {
            var topPlayers = Service.GetTopPlayers(25);
            var viewModel = new TopPlayersViewModel() { TopPlayers = Service.GetTopPlayers(25) };
            return View(viewModel);
        }
    }
}