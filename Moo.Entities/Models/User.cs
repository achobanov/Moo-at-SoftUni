using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Entities.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        [Index(IsUnique =true)]
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Email { get; set; }
        public IEnumerable<Role> Roles { get; set; }
        public IEnumerable<Game> GamesPlayed { get; set; }
    }
}
