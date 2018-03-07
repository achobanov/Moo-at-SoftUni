using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Entities.ViewModels.Game
{
    public class GuessViewModel
    {
        [Required(ErrorMessage = "Are you affraid to guess, puny mortal?")]
        [StringLength(4, ErrorMessage = "4 Digits, mortal. You don't want to try with less/more")]
        public string Guess { get; set; }
    }
}
