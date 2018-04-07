using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {

        public int Add(string numberString)
        {
            List<char> defaultDelimiters = new List<char> { ',', '\n' };

            defaultDelimiters.Add(GetAdditionalDelimiters(ref numberString));

            if (string.IsNullOrEmpty(numberString)) return 0;

            var splitString = numberString.Split(defaultDelimiters.ToArray()
                , StringSplitOptions.RemoveEmptyEntries);

            var total = CalculateSum(splitString);
            return total;
        }

        private static int CalculateSum(IEnumerable<string> numbers)
        {
            var values = numbers.Select(number => int.Parse(number)).Where(i=>i<=1000);
            if (values.Any(number => number < 0))
            {
                var errorMessage = string.Join(",", values.Where(number => number < 0)).Trim();
                throw new ApplicationException(errorMessage);
            }

            return values.Sum();
        }

        private static int ParseValues(string i)
        {
            var value = int.Parse(i);
            return int.Parse(i);
        }

        public char GetAdditionalDelimiters(ref string numberString)
        {
            var delimiterString = numberString.IndexOf("//", StringComparison.Ordinal);
            if (delimiterString <= -1) return char.MinValue;
            var delimiter = numberString.Substring(delimiterString + 2, 1);

            numberString = numberString.Replace("//" + delimiter + "\n", "");
            return delimiter[0];
        }
    }
}