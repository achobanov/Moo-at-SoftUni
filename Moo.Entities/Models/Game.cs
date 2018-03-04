using Moo.Entities.DataEntities;
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
        public bool UserWon { get; set; }
        public bool Draw { get; set; }
        public IEnumerable<AttemptData> Attempts { get; set; }
        public IEnumerable<AttemptData> OponentAttempts { get; set; }
    }
}
