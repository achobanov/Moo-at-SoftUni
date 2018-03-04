using System.Collections.Generic;

namespace Moo.Entities.Models
{
    public class Role
    {
        public int ID { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}