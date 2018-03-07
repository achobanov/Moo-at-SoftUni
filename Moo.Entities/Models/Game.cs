using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Moo.Entities.Models
{
    public class Game
    {   
        public int ID { get; set; } 
        [Required]
        public int UserID { get; set; }
        [Required]
        public string UserNumber { get; set; }
        [Required]
        public string OpponentNumber { get; set; }
        public string CurrentAction { get; set; }
        public bool UserWon { get; set; }
        public bool Draw { get; set; }
        public ICollection<Turn> Turns { get; set; }
    }
}
