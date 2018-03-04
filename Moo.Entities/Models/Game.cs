using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Entities.Models
{
    public class Game
    {   
        public int ID { get; set; } 
        [Required]
        public int UserID { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public bool HasUserWon { get; set; }
    }
}
