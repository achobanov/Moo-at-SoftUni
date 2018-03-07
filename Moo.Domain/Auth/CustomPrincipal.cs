using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Domain.Auth
{
    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }

        public int UserId { get; set; }
        public int? ActiveGameID { get; set; }
        public string[] Roles { get; set; }

        public CustomPrincipal(string username)
        {
            Identity = new GenericIdentity(username);
        }

        public bool IsInRole(string role)
        {
            return Roles.Any(r => role.Contains(r));
        }
    }
}
