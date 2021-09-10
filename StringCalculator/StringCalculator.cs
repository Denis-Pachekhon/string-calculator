using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class StringCalculator
    {
        private const int SUM_FOR_AN_EMPTY_STRING = 0;

        public int Add(string numbers)
        {
            if (String.IsNullOrEmpty(numbers))
            {
                return SUM_FOR_AN_EMPTY_STRING;
            }

            return Convert.ToInt32(numbers);
        }
    }
}
