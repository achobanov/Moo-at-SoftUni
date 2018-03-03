using Moo.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Domain.DataInterfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetTopPerformingUsers(int amount);
        User Get(string username, string password);
        User Get(string username);
        User GetByEmail(string email);
        IUserRepository Include(string include);
    }
}
