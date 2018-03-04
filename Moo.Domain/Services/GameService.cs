using Moo.Domain.DataInterfaces;
using Moo.Entities.Interfaces;
using Moo.Entities.Models;
using Moo.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Domain.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork Unit;

        public GameService(IUnitOfWork unit)
        {
            this.Unit = unit;
        }

        public IEnumerable<TopPlayerViewModel> GetTopPlayers(int amount)
        {
            var topPerformingUsers = Unit.Users.GetTopPerformingUsers(amount, include: "GamesPlayed");
            var topPlayers = new List<TopPlayerViewModel>();
            foreach (var user in topPerformingUsers)
            {
                var gamesWon = Unit.Games.GetNumberOfWonGamesByUser(user.ID);
                var gamesPlayed = user.GamesPlayed.Count();
                topPlayers.Add(new TopPlayerViewModel()
                {
                    Username = user.Username,
                    GamesWon = gamesWon,
                    GamesLost = gamesPlayed - gamesWon,
                    WinPercent = Math.Round((double) gamesWon / gamesPlayed) * 100
                });
            }
            return topPlayers;
        }
    }
}
