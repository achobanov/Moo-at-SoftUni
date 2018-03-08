using Moo.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Moo.Domain.OpponentPlayer
{
    public class Tools
    {
        private Random Random;

        public Tools()
        {
            this.Random = new Random();
        }

        public string GenerateNumber()
        {
            var digits = new int[4];
            for (var i = 0; i < 4; i++)
            {
                int digit;
                do
                    digit = Random.Next(0, 9);
                while (digits.Contains(digit));
                digits[i] = digit;
            }

            return string.Join("", digits);
        }

        public IEnumerable<string> GetPermutations(int size)
        {
            if (size > 0)
            {
                foreach (string s in GetPermutations(size - 1))
                {
                    foreach (char n in s.Length == 0 ? "123456789" : "0123456789")
                    {
                        if (!s.Contains(n))
                        {
                            yield return s + n;
                        }
                    }
                }
            }
            else
                yield return "";
        }

        public string SelectRandomValue(List<string> values)
        {
            if (values.Count == 0)
                return Constants.CHEATER;
            if (values.Count == 1)
                return values[0];

            var index = Random.Next(values.Count() - 1);
            var randomValue = values[index];
            values.RemoveAt(index);
            return values[index];
        }

        public void CountCowsAndBulls(string userGuess, string opponentNumber, out int bulls, out int cows)
        {
            bulls = cows = 0;
            for (int i = 0, n = opponentNumber.Length; i < n; i++)
            {
                if (userGuess[i] == opponentNumber[i])
                    bulls++;
                else
                    if (opponentNumber.Contains(userGuess[i]))
                    cows++;
            }
        }
    }
}
