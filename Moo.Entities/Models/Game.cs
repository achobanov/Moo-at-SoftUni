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
        public bool UserWon { get; set; }
        public bool Draw { get; set; }
        public ICollection<Turn> UserTurns { get; set; }
        public ICollection<OpponentTurn> OpponentTurns { get; set; }
    }
}
