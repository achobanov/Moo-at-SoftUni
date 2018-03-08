using Moo.Entities.DataEntities;
using Moo.Entities.Models;
using Moo.Entities.ViewModels;
using Moo.Entities.ViewModels.Game;
using System.Collections.Generic;

namespace Moo.Entities.Interfaces
{
    public interface IGameService
    {
        IEnumerable<TopPlayerData> GetTopPlayers(int amount);
        void InitiateGame(string userNumber);
        GameViewModel GetActiveGame(bool isLoadingFromDb = false);
        bool HandleUserGuess(GuessData data, out int bools, out int cows);
        string HandleOpponentGuess(GuessData data);
        Turn HandleUserResponse(ResponseData data);
        GameViewModel EndGame(int gameId, string status);
    }
}
