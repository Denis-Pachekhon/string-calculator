using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class FindNegativesException : Exception
    {
        public FindNegativesException(List<int> negatives) : base(ChangeToString(negatives))
        {

        }

        private static string ChangeToString(List<int> negatives)
        {
            return "Negatives not allowed: " + String.Join(", ", negatives);
        }
    }
}
