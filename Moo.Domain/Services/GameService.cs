using Moo.Domain.Auth;
using Moo.Domain.DataInterfaces;
using Moo.Domain.OpponentPlayer;
using Moo.Entities.ViewModels;
using Moo.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Moo.Entities.Models;
using Moo.Entities.DataEntities;
using Moo.Entities.ViewModels.Game;
using Moo.Common;

namespace Moo.Domain.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork Unit;
        private readonly Opponent Opponent;

        public GameService(IUnitOfWork unit, Opponent opponent)
        {
            this.Unit = unit;
            this.Opponent = opponent;
        }

        public IEnumerable<TopPlayerData> GetTopPlayers(int amount)
        {
            var topPerformingUsers = Unit.Users.GetTopPerformingUsers(amount, include: "GamesPlayed");
            var topPlayers = new List<TopPlayerData>();
            foreach (var user in topPerformingUsers)
            {
                var gamesWon = Unit.Games.GetNumberOfWonGamesByUser(user.ID);
                var gamesPlayed = user.GamesPlayed.Count();
                topPlayers.Add(new TopPlayerData()
                {
                    Username = user.Username,
                    GamesWon = gamesWon,
                    GamesLost = gamesPlayed - gamesWon,
                    WinPercent = Math.Truncate((double) gamesWon / gamesPlayed * 100)
                });
            }
            return topPlayers;
        }

        public int InitiateGame(string userNumber)
        {
            var userId = GetCurrentUserId();
            var gameId = CreateGame(userId, userNumber);
            var user = Unit.Users.Get(userId);
            user.ActiveGameID = gameId;
            Unit.Complete();

            return gameId;
        }

        public GameViewModel GetActiveGame(bool isLoadingFromDb = false)
        {
            var userId = GetCurrentUserId();
            var user = Unit.Users.Get(userId);
            if (user.ActiveGameID != null)
            {
                var game = Unit.Games.Get((int)user.ActiveGameID, "Turns");
                var viewModel = new GameViewModel()
                {
                    GameID = game.ID,
                    UserNumber = game.UserNumber,
                    PostFormToAction = game.CurrentAction,
                    OpponentNumberSlots = new string[] { "", "", "", "" }
                };
                if (isLoadingFromDb && game.Turns.Count() != 0)
                {
                    var lastTurn = game.Turns.OrderByDescending(t => t.Index).FirstOrDefault();
                    viewModel.Guess = lastTurn.Guess;
                    viewModel.Bulls = (int)lastTurn.Bulls;
                    viewModel.Cows = (int)lastTurn.Cows;
                }
                if (game.Turns == null)
                {
                    viewModel.UserTurns = new List<Turn>();
                    viewModel.OpponentTurns = new List<Turn>();
                    viewModel.Rounds = 0;
                }
                else
                {
                    viewModel.UserTurns = game.Turns.Where(t => t.Action == Constants.USER_GUESS).ToList();
                    viewModel.OpponentTurns = game.Turns.Where(t => t.Action == Constants.OPPONENT_GUESS).ToList();
                    viewModel.Rounds = viewModel.UserTurns.Count();
                }
                return viewModel;
            }
            else
                return null;
        }

        private int CreateGame(int userId, string userNumber)
        {
            var newGame = new Entities.Models.Game()
            {
                UserID = userId,
                UserNumber = userNumber,
                OpponentNumber = Opponent.ChooseNumber(),
                CurrentAction = Constants.USER_GUESS
            };
            Unit.Games.Add(newGame);
            Unit.Complete();

            return newGame.ID;
        }

        private int GetCurrentUserId()
        {
            var userContext = System.Web.HttpContext.Current.User as CustomPrincipal;
            return userContext.UserId;
        }

        public void HandleUserGuess(GuessData data, out int bulls, out int cows)
        {
            var game = Unit.Games.Get(data.GameID, "Turns");
            if (game == null)
                throw new Exception("Game not found!");

            var opponentNumber = game.OpponentNumber;
            Opponent.RespondToUser(data.Guess, opponentNumber, out bulls, out cows);

            Unit.Turns.Add(new Turn()
            {
                Action = Constants.USER_GUESS,
                Guess = data.Guess,
                GameID = data.GameID,
                Bulls = bulls,
                Cows = cows,
                Index = game.Turns.Count()
            });
            game.CurrentAction = Constants.OPPONENT_GUESS;
            Unit.Complete();
        }

        public string HandleOpponentGuess(GuessData data)
        {
            var opponentTurns = Unit.Turns.GetOpponentTurns(data.GameID).ToList();
            Unit.Games.Get(data.GameID).CurrentAction = Constants.USER_RESPONSE;
            return Opponent.ChooseNextGuess(opponentTurns);
        }

        public void HandleUserResponse(ResponseData data)
        {
            var numberOfUserTurns = 0;
            var numberOfOpponentTurns = 0;
            if (data.UserTurns != null)
                numberOfUserTurns = data.UserTurns.Count();
            if (data.OpponentTurns != null)
                numberOfOpponentTurns = data.OpponentTurns.Count();

            Unit.Turns.Add(new Turn()
            {
                Action = Constants.OPPONENT_GUESS,
                Index = numberOfUserTurns + numberOfOpponentTurns,
                GameID = data.GameID,
                Guess = data.Guess,
                Bulls = data.Bulls,
                Cows = data.Cows
            });
            Unit.Games.Get(data.GameID).CurrentAction = Constants.USER_GUESS;
            Unit.Complete();
        }
    }
}
