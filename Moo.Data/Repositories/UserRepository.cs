using Moo.Data.Context;
using Moo.Data.Generic;
using Moo.Domain.DataInterfaces;
using Moo.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Data.Repositories
{
    class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MooDbContext context) : base(context)
        { }

        public IEnumerable<User> GetTopPerformingUsers(int amount, params string[] include)
        {
            var users = Include(include);
            return users
                .Where(u => u.GamesPlayed.Any())
                .OrderByDescending(u =>
                    (double) u.GamesPlayed.Where(g => g.UserWon == true).Count() / u.GamesPlayed.Count())
                .Take(amount)
                .ToList();
        }

        public User Get(string username, params string[] include)
        {
            var users = Include(include);
            return users
                .Where(u => string.Compare(username, u.Username, StringComparison.OrdinalIgnoreCase) == 0)
                .FirstOrDefault();
        }
    }
}
