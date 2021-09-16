using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private const int SUM_FOR_Null_Or_White_Space_STRING = 0;
        private List<string> SEPERATORS = new List<string>() { ",", "\n" };

        public int Add(string numbersString)
        {
            if (String.IsNullOrWhiteSpace(numbersString))
            {
                return SUM_FOR_Null_Or_White_Space_STRING;
            }

            if (numbersString.StartsWith("//"))
            {
                UpdateSeparatorsList(numbersString);
            }

            var result = numbersString.Split(SEPERATORS.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Where(x => int.TryParse(x, out int value))
                .Select(n => int.Parse(n))
                .Sum();

            return result;
        }

        private void UpdateSeparatorsList(string numbersString)
        {
            var seperator = string.Concat(numbersString.Skip(2).TakeWhile(x => !x.Equals('\n')));

            SEPERATORS.Add(seperator);
        }
    }
}
