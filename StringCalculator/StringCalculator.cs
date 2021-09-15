using System;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private const int SUM_FOR_Null_Or_White_Space_STRING = 0;

        public int Add(string numbers)
        {
            if (String.IsNullOrWhiteSpace(numbers))
            {
                return SUM_FOR_Null_Or_White_Space_STRING;
            }

            var result = numbers.Split(',')
                .Select(n => int.Parse(n))
                .Sum();

            return result;
        }
    }
}
