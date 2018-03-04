using Moo.Entities.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Entities.ViewModels
{
    public class PlayViewModel
    {
        public AttemptData CurrentAttempt { get; set; }
        public IEnumerable<AttemptData> Attempts { get; set; }
        public AttemptData OpponentAttempt { get; set; }
    }
}
