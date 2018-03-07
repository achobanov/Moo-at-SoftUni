using Moo.Common;
using Moo.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Moo.Domain.OpponentPlayer
{
    public class Opponent
    {
        private readonly Tools Tools;

        public Opponent (Tools tools)
        {
            this.Tools = tools;
        }

        public string ChooseNumber()
        {
            return Tools.GenerateNumber();
        }

        public void RespondToUser(string guess, string number, out int bulls, out int cows)
        {
            Tools.CountCowsAndBulls(guess, number, out bulls, out cows);
        }

        public string ChooseNextGuess(ICollection<Turn> previousTurns)
        {
            var permutations = Tools.GetPermutations(Constants.NUMBER_LENGTH).ToList();
            if (previousTurns != null)
            {
                foreach (var turn in previousTurns)
                    RemoveInvalidGuesses(permutations, turn.Guess, (int)turn.Bulls, (int)turn.Cows);
            }

            return Tools.SelectRandomValue(permutations as List<string>);
        }

        private void RemoveInvalidGuesses(ICollection<string> possibleGuesses, string guess, int bulls, int cows)
        {
            foreach (var possibleGuess in possibleGuesses.ToList())
            {
                Tools.CountCowsAndBulls(guess, possibleGuess, out int possibleBulls, out int possibleCows);
                if (possibleBulls != bulls || possibleCows != cows)
                    possibleGuesses.Remove(possibleGuess);
            }
        }
    }
}
