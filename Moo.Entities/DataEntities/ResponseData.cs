using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Entities.DataEntities
{
    public class ResponseData
    {
        public int GameID { get; set; }
        public int Bulls { get; set; }
        public int Cows { get; set; }
        public string Guess { get; set; }
        public int Rounds { get; set; }
    }
}
