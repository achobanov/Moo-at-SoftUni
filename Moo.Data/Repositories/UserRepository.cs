using Moo.Data.Context;
using Moo.Data.Generic;
using Moo.Domain.DataInterfaces;
using Moo.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Data.Repositories
{
    class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MooDbContext context) : base(context)
        { }

        public IEnumerable<User> GetTopPerformingUsers(int amount)
        {
            return mooDbContext.Users
                .ToList()
                .OrderByDescending(u =>
                    u.GamesPlayed.Where(g => g.HasUserWon).Count() / u.GamesPlayed.Count())
                .Take(amount);
                
        }

        private MooDbContext mooDbContext
        {
            get { return this.context as MooDbContext; }
        }
    }
}
