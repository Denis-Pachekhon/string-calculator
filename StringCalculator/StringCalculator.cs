using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private const int SUM_FOR_AN_EMPTY_STRING = 0;
        private int Count = 0;
        private const int MAX_NUMBER = 1000;
        private List<string> SEPERATORS = new List<string>() { ",", "\n" };
        private const string INDICATOR = "//";
        public event Action<string, int> AddOccured;

        public int Add(string numbers)
        {
            Count++;

            if (String.IsNullOrWhiteSpace(numbers))
            {
                return SUM_FOR_AN_EMPTY_STRING;
            }

            if (numbers.StartsWith(INDICATOR))
            {
                AddNewSeperators(numbers);

                numbers = ClearStringOfNumbersFromTheIndicators(numbers);
            }

            var listNumbers = GetNumbers(numbers);

            int sum = listNumbers.Sum();

            if (AddOccured != null)
            { 
                AddOccured.Invoke(numbers, sum);
            }

            return sum;
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
                    throw new ApplicationException("Negatives not allowed: " + GetNegativeNumbers(nums));
                }

                if (number <= MAX_NUMBER)
                {
                    listNumbers.Add(number);
                }
            }

            return listNumbers;
        }

        private void AddNewSeperators(string numbers)
        {
            string[] indicators = { INDICATOR, "[", "]" };

            var customSeperator = numbers.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).First();

            var seperators = customSeperator.Split(indicators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var seperator in seperators)
            {
                SEPERATORS.Add(seperator);
            }
        }

        private string ClearStringOfNumbersFromTheIndicators(string numbers)
        {
            var customSeperator = numbers.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).First();

            numbers = numbers.Substring(customSeperator.Length, numbers.Length - customSeperator.Length);

            return numbers;
        }

        private string GetNegativeNumbers(string[] nums)
        {
            return String.Join(", ", nums.Where(x => int.Parse(x) < 0).Select(x => x.ToString()));
        }

        public int GetCalledCount()
        {
            return Count;
        }
    }
}
