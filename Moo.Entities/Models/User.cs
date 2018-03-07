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
        [Index(IsUnique = true)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public int? ActiveGameID { get; set; }
        public ICollection<Role> Roles { get; set; }
        public ICollection<Game> GamesPlayed { get; set; }
    }
}
