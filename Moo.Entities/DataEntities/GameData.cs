using Moo.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Entities.DataEntities
{
    public class GameData
    {
        public int ID { get; set; }
        public List<Turn> UserTurns { get; set; }
        public List<Turn> OpponentTurns { get; set; }

    }
}
