using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {

        public int Add(string numberString)
        {
            char[] delimiter = new char[] { ',', '\n' };

            if (string.IsNullOrEmpty(numberString)) return 0;

            var splitString = numberString.Split(delimiter);
            var total = CalculateSum(splitString);
            return total;
        }

        private static int CalculateSum(string[] numbers)
        {
            return numbers.Select(i => int.Parse(i)).Sum();
        }
    }
}