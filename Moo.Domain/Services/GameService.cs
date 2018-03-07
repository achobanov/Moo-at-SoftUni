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

namespace Moo.Domain.Services
{
    public class GameService : IGameService
    {
        private const string USER_RESPONSE = "USER_RESPONSE";
        private const string USER_GUESS = "USER_GUESS";
        private const string AI_GUESS = "AI_GUESS";

        private readonly IUnitOfWork Unit;
        private readonly Opponent Opponent;
        private readonly Tools Tools;

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

        public Game GetActiveGame()
        {
            var userId = GetCurrentUserId();
            var user = Unit.Users.Get(userId);
            if (user.ActiveGameID != null)
            {
                var game = Unit.Games.Get((int)user.ActiveGameID, "UserTurns", "OpponentTurns");
                if (game.UserTurns == null)
                {
                    game.UserTurns = new List<Turn>();
                    game.OpponentTurns = new List<OpponentTurn>();
                }
                return game;
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
                OpponentNumber = Opponent.ChooseNumber()
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
            var game = Unit.Games.Get(data.GameID);
            if (game == null)
                throw new Exception("Game not found!");

            var opponentNumber = game.OpponentNumber;
            Opponent.RespondToUser(data.Guess, opponentNumber, out bulls, out cows);

            Unit.Turns.Add(new Turn()
            {
                Action = USER_GUESS,
                Guess = data.Guess,
                GameID = data.GameID,
                Bulls = bulls,
                Cows = cows,
                Index = data.Rounds + 1
            });
            Unit.Complete();
        }

        public void HandleUserResponse(ResponseData data)
        {
            Unit.Turns.Add(new OpponentTurn()
            {
                Action = AI_GUESS,
                Index = data.Rounds,
                GameID = data.GameID,
                Guess = data.Guess,
                Bulls = data.Bulls,
                Cows = data.Cows
            });
            Unit.Complete();
        }

        public string HandleOpponentGuess(GuessData data)
        {
            var opponentTurns = Unit.Turns.GetOpponentTurns(data.GameID) as ICollection<OpponentTurn>;
            return Opponent.ChooseNextGuess(opponentTurns);
        }
    }
}
