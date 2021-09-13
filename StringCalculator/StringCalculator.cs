using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private const int SUM_FOR_AN_EMPTY_STRING = 0;
        private List<string> SEPERATORS = new List<string>() { ",", "\n" };
        private const string INDICATOR = "//";

        public int Add(string numbers)
        {
            if (String.IsNullOrWhiteSpace(numbers))
            {
                return SUM_FOR_AN_EMPTY_STRING;
            }

            if (numbers.StartsWith(INDICATOR))
            {
                numbers = SearchNewSeperators(numbers);
            }

            var listNumbers = GetNumbers(numbers);

            return listNumbers.Sum();
        }
            
        private List<int> GetNumbers(string numbers)
        {
            var nums = numbers.Split(SEPERATORS.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            var listNumbers = new List<int>();

            foreach (var num in nums)
            {
                var number = int.Parse(num);

                if (number < 0)
                {
                    throw new ApplicationException("Negatives not allowed " + number);
                }

                listNumbers.Add(number);
            }

            return listNumbers;
        }

        private string SearchNewSeperators(string numbers)
        {
            var customSeperator = numbers.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).First();

            numbers = numbers.Substring(customSeperator.Length, numbers.Length - customSeperator.Length);

            var seperator = string.Concat(customSeperator.Skip(2));

            SEPERATORS.Add(seperator);

            return numbers;
        }
    }
}
