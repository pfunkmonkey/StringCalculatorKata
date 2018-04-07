using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {

        public int Add(string numberString)
        {
            List<char> defaultDelimiters = new List<char>{ ',', '\n' };

            var delimiterString= numberString.IndexOf("//", StringComparison.Ordinal);
            if (delimiterString > -1)
            {
                var delimiter = numberString.Substring(delimiterString+2,1);
              
                numberString = numberString.Replace("//" + delimiter + "\n", "");
                defaultDelimiters.Add(delimiter[0]);
            }

            if (string.IsNullOrEmpty(numberString)) return 0;

            var splitString = numberString.Split(defaultDelimiters.ToArray(),StringSplitOptions.RemoveEmptyEntries);
            var total = CalculateSum(splitString);
            return total;
        }

        private static int CalculateSum(string[] numbers)
        {
            return numbers.Select(i => int.Parse(i)).Sum();
        }
    }
}