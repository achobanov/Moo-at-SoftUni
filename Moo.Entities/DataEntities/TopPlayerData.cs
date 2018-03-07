using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Entities.ViewModels
{
    public class TopPlayerData
    {
        public string Username { get; set; }
        public double WinPercent { get; set; }
        public int GamesWon { get; set; }
        public int GamesLost { get; set; }
    }
}
