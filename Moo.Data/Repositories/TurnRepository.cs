using Moo.Common;
using Moo.Data.Context;
using Moo.Domain.DataInterfaces;
using Moo.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Moo.Data.Repositories
{
    class TurnRepository : Repository<Turn>, ITurnRepository
    {
        public TurnRepository(MooDbContext context) : base(context)
        { }

        public IEnumerable<Turn> GetOpponentTurns(int gameId)
        {
            return MooDbContext.Turns
                .Where(t => t.GameID == gameId
                    && t.Action.Equals(Constants.OPPONENT_GUESS));       
        }

        public Turn GetLastOpponentTurn(int gameId)
        {
            return Include("PossibleGuesses.Guess")
                .Where(t => gameId == t.GameID
                    && t.Action == "AI_GUESS")
                .OrderByDescending(t => t.Index)
                .FirstOrDefault();
        }
    }
}
