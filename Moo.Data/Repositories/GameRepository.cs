using Moo.Data.Context;
using Moo.Data.Generic;
using Moo.Domain.DataInterfaces;
using Moo.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Data.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(MooDbContext context) : base(context)
        { }

        public int GetNumberOfWonGamesByUser(int userId)
        {
            return MooDbContext.Games
                .Where(g => userId == g.UserID
                    && g.UserWon == true)
                .Count();
        }
    }
}
