using System;
using System.Linq;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
      
            public int Add(string numberString)
            {
            if (string.IsNullOrEmpty(numberString)) return 0;
                var numbers=numberString.Split(new []{',','\n'});
                var total=CalculateSum(numbers);
                return total;
            }

        private static int CalculateSum(string[] numbers)
        {
            return numbers.Select(i=>int.Parse(i)).Sum();
        }
    }
}