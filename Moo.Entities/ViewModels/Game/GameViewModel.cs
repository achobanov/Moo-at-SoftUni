using Moo.Entities.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Moo.Entities.ViewModels.Game
{
    public class GameViewModel : ViewModel
    {
        public int GameID { get; set; }
        public string UserNumber { get; set; }
        public int Rounds { get; set; }
        public List<Turn> UserTurns { get; set; }
        public List<OpponentTurn> OpponentTurns { get; set; }

        public string Guess { get; set; }

        public int Bulls { get; set; }
        public int Cows { get; set; }

        public string FormAction { get; set; }
    }
}
