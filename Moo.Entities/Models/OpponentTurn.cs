using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Entities.Models
{
    public class OpponentTurn : Turn
    {
        public ICollection<string> PossibleGuesses { get; set; }
    }
}
