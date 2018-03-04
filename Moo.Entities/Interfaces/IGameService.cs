using Moo.Entities.DataEntities;
using Moo.Entities.Models;
using Moo.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Entities.Interfaces
{
    public interface IGameService
    {
        IEnumerable<TopPlayerData> GetTopPlayers(int amount);
        AttemptData HandleRound(string userAttempt, bool isInitialRound);
    }
}
