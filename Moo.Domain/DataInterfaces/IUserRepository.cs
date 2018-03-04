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
        IEnumerable<User> GetTopPerformingUsers(int amount, params string[] include);
        User Get(string username, params string[] include);
        User GetByEmail(string email);
    }
}
