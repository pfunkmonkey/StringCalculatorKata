using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {

        public int Add(string numberString)
        {
            var subStringId = 1;

            List<char> delimiter = new List<char>();

            if (string.IsNullOrEmpty(numberString)) return 0;
                var values = numberString.IndexOf("//", StringComparison.Ordinal);

                if (values >-1)
                    delimiter.Add(numberString[values + 2]);
            delimiter.AddRange(new List<char> { ',', '\n' });


            var splitString = numberString.Split(delimiter.ToArray());
            var total = CalculateSum(splitString);
            return total;
        }

        private static int CalculateSum(string[] numbers)
        {
            return numbers.Select(i => int.Parse(i)).Sum();
        }
    }
}