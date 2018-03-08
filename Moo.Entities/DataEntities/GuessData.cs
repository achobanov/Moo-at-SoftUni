
namespace Moo.Entities.DataEntities
{
    public class GuessData
    {
        public int GameID { get; set; }
        public string Guess { get; set; }
        public int Rounds { get; set; }
        public string[] OpponentNumberSlots { get; set; }
    }
}
