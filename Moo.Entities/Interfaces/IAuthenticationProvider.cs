using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Moo.Entities.Interfaces
{
    public interface IAuthenticationProvider
    {
        bool ValidateUser(string username, string password);
        MembershipUser GetUser(string username, bool userIsOnline);
        string GetUserNameByEmail(string email);
    }
}
