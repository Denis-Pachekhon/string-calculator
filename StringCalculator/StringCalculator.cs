using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private const int SUM_FOR_AN_EMPTY_STRING = 0;
        private List<char> SEPERATORS = new List<char>() { ',', '\n' };

        public int Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
            {
                return SUM_FOR_AN_EMPTY_STRING;
            }

            var listNumbers = GetNumbers(numbers);

            return listNumbers.Sum();
        }
            
        private List<int> GetNumbers(string numbers)
        {
            var nums = numbers.Split(SEPERATORS.ToArray());

            var listNumbers = new List<int>();

            foreach (var num in nums)
            {
                var number = int.Parse(num);

                listNumbers.Add(number);
            }

            return listNumbers;
        }
    }
}
