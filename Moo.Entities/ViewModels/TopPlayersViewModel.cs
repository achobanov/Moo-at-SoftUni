using Moo.Entities.DataEntities;
using Moo.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moo.Entities.ViewModels
{
    public class TopPlayersViewModel : ViewModel
    {
        public IEnumerable<TopPlayerData> TopPlayers { get; set; }
    }
}
