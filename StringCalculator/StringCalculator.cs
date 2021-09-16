using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private const int SUM_FOR_Null_Or_White_Space_STRING = 0;
        private List<string> SEPERATORS = new List<string>() { ",", "\n" };
        private int Count = 0;
        public event Action<string, int> AddOccured;

        public int Add(string numbersString)
        {
            Count++;

            if (String.IsNullOrWhiteSpace(numbersString))
            {
                return SUM_FOR_Null_Or_White_Space_STRING;
            }

            if (numbersString.StartsWith("//"))
            {
                UpdateSeparatorsList(numbersString);
            }

            var numbersList = GetCleanNumbers(numbersString);

            if (CheckForNegativeNumbers(numbersList))
            {
                throw new ApplicationException("Negatives not allowed: " + GetNegativeNumbers(numbersList));
            }

            int sum = numbersList.Sum();

            if (AddOccured != null)
            {
                AddOccured.Invoke(numbersString, sum);
            }

            return sum;
        }

        private void UpdateSeparatorsList(string numbersString)
        {
            var seperator = string.Concat(numbersString.Skip(2).TakeWhile(x => !x.Equals('\n')));

            SEPERATORS.Add(seperator);
        }

        private List<int> GetCleanNumbers(string numbersString)
        {
            return numbersString.Split(SEPERATORS.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Where(x => int.TryParse(x, out int value))
                .Select(n => int.Parse(n)).ToList();
        }

        private bool CheckForNegativeNumbers(List<int> numbersList)
        {
            return numbersList.Any(x => x < 0);
        }

        private string GetNegativeNumbers(List<int> numbersList)
        {
            return String.Join(", ", numbersList.Where(x => x < 0).Select(x => x.ToString()));
        }

        public int GetCalledCount()
        {
            return Count;
        }
    }
}
