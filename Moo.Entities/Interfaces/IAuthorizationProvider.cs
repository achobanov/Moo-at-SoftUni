using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Entities.Interfaces
{
    public interface IAuthorizationProvider
    {
        bool IsUserInRole(string username, string password);
        string[] GetRolesForUser(string username);
    }
}
