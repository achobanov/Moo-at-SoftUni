using Moo.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Entities.ViewModels.Game
{
    public class ResponseViewModel
    {
        [Required(ErrorMessage = "Play fair, mortal! How many bulls?")]
        [Range(0, Constants.NUMBER_LENGTH)]
        public int Bulls { get; set; }

        [Required(ErrorMessage = "Play fair, mortal! How many cows?")]
        [Range(0, Constants.NUMBER_LENGTH)]
        public int Cows { get; set; }
    }
}
