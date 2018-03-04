using Moo.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace Moo.Domain.Auth
{
    class CustomMembershipUser : MembershipUser
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Role> Roles { get; set; }

        public CustomMembershipUser(User user) 
            : base("AuthenitcationProvider", 
                  user.Username, 
                  user.ID,
                  string.Empty,
                  string.Empty, 
                  string.Empty, 
                  true, 
                  false, 
                  DateTime.Now, 
                  DateTime.Now, 
                  DateTime.Now, 
                  DateTime.Now, 
                  DateTime.Now)
        {
            UserId = user.ID;
            Roles = user.Roles;
        }
    }
}
