using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private List<string> SEPERATORS = new List<string>() { ",", "\n" };
        public int Count { get; private set; } = 0;
        public event Action<string, int> AddOccured;

        public int Add(string numbersString)
        {
            Count++;

            if (String.IsNullOrWhiteSpace(numbersString))
            {
                return 0;
            }

            if (numbersString.StartsWith("//"))
            {
                UpdateSeparatorsList(numbersString);
                numbersString = GetNumbersAndDelimitersString(numbersString);
            }

            var numbersList = GetCleanNumbers(numbersString);

            if (CheckForNegativeNumbers(numbersList))
            {
                throw new ApplicationException("Negatives not allowed: " + GetNegativeNumbers(numbersList));
            }

            int sum = numbersList.Where(n => n <= 1000).Sum();

            AddOccured?.Invoke(numbersString, sum);

            return sum;
        }

        private void UpdateSeparatorsList(string numbersString)
        {
            string[] customSeparatorIndicators = { "[", "]" };

            var customSeparatorsString = string.Concat(numbersString.Skip(2).TakeWhile(n => !n.Equals('\n')));

            var seperators = customSeparatorsString.Split(customSeparatorIndicators, StringSplitOptions.RemoveEmptyEntries);

            SEPERATORS.AddRange(seperators);
        }

        private string GetNumbersAndDelimitersString(string numbersString)
        {
            return string.Concat(numbersString.SkipWhile(n => !n.Equals('\n')));
        }

        private List<int> GetCleanNumbers(string numbersString)
        {
            return numbersString.Split(SEPERATORS.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n)).ToList();
        }

        private bool CheckForNegativeNumbers(List<int> numbersList)
        {
            return numbersList.Any(n => n < 0);
        }

        private string GetNegativeNumbers(List<int> numbersList)
        {
            return String.Join(", ", numbersList.Where(n => n < 0).Select(n => n.ToString()));
        }
    }
}
