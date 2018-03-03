using Moo.Data.Context;
using Moo.Data.Generic;
using Moo.Domain.DataInterfaces;
using Moo.Entities.Models;
using System;
using System.Collections.Generic;
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

        public IEnumerable<User> GetTopPerformingUsers(int amount)
        {
            return MooDbContext.Users
                .OrderByDescending(u =>
                    u.GamesPlayed.Where(g => g.HasUserWon).Count() / u.GamesPlayed.Count())
                .Take(amount);
                
        }

        public User Get(string username, string password)
        {
            return MooDbContext.Users
                .Where(u =>
                    string.Compare(username, u.Username, StringComparison.OrdinalIgnoreCase) == 0
                    && string.Compare(password, u.Password, StringComparison.OrdinalIgnoreCase) == 0)
                .FirstOrDefault();
        }

        public User Get(string username)
        {
            return MooDbContext.Users
                .Where(u => string.Compare(username, u.Username, StringComparison.OrdinalIgnoreCase) == 0)
                .FirstOrDefault();
        }

        public User GetByEmail(string email)
        {
            return MooDbContext.Users
                .Where(u => string.Compare(email, u.Email) == 0)
                .FirstOrDefault();
        }

        public IUserRepository Include(string include)
        {
            var set = MooDbContext.Users;
            set.Include(include);
            return this;
        }

        private MooDbContext MooDbContext
        {
            get { return this.context as MooDbContext; }
        }
    }
}
