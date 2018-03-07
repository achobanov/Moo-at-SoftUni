using Moo.Entities.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Moo.Entities.ViewModels.Game
{
    public class GameViewModel : ViewModel
    {
        public int GameID { get; set; }
        [DisplayName("Your secret number")]
        public string UserNumber { get; set; }
        public int Rounds { get; set; }
        public List<Turn> UserTurns { get; set; }
        public List<Turn> OpponentTurns { get; set; }
        public string[] OpponentNumberSlots { get; set; }

        public string Guess { get; set; }

        public int Bulls { get; set; }
        public int Cows { get; set; }

        public string PostFormToAction { get; set; }
    }
}
