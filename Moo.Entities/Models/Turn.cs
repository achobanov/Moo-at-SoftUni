using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Entities.Models
{
    public class Turn
    {
        public int ID { get; set; }
        [Required]
        public int GameID { get; set; }
        [Required]
        public int Index { get; set; }
        public string Action { get; set; }
        public string Guess { get; set; }
        public int? Cows { get; set; }
        public int? Bulls { get; set; }
    }
}
