using Moo.Domain.Auth;
using Moo.Domain.DataInterfaces;
using Moo.Domain.Game;
using Moo.Entities.DataEntities;
using Moo.Entities.Interfaces;
using Moo.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;

namespace Moo.Domain.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork Unit;
        private readonly AI AI;
        private readonly Tools Tools;

        public GameService(IUnitOfWork unit, AI ai, Tools tools)
        {
            this.Unit = unit;
            this.AI = ai;
            this.Tools = tools;
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

        public GameData HandleRound(string userAttempt, bool isInitialRound)
        {
            if (isInitialRound)
            {
                var userContext = System.Web.HttpContext.Current.User as CustomPrincipal;
                var user = Unit.Users.Get(userContext.UserId);
                var gameId = CreateGame(user.ID, userAttempt);
                user.ActiveGameID = gameId;
                return new GameData()
                {
                    Started = false,
                    UserNumber = ""
                };
            } 

            var response = 
        }

        private int CreateGame(int userId, string userNumber)
        {
            var newGame = new Entities.Models.Game()
            {
                UserID = userId,
                UserNumber = userNumber, 
                OponentNumber = Tools.GenerateNumber()
            };
            Unit.Games.Add(newGame);
            Unit.Complete();

            return newGame.ID;
        }
    }
}
