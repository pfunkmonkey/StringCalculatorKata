using System;
using NUnit.Framework;
using StringCalculatorKata;

namespace StringCalculatorTests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void StringCalculator_WhenEmpty_ReturnZero()
        {
            var stringCalculator = new StringCalculator();
            var total = stringCalculator.Add("");
            Assert.IsTrue(total == 0);
        }

        [Test]
        public void StringCalculator_When1Digit_ReturnValue()
        {
            var stringCalculator = new StringCalculator();
            var total = stringCalculator.Add("7");
            Assert.IsTrue(total == 7);
        }

        [Test]
        public void StringCalculator_When2Digit_SumOfValuesReturnedWillBe9()
        {
            var stringCalculator = new StringCalculator();
            var total = stringCalculator.Add("7,2");
            Assert.IsTrue(total == 9);
        }

        [Test]
        public void StringCalculator_When3Digits_SumOfValuesReturnedWilBe14()
        {
            var stringCalculator = new StringCalculator();
            var total = stringCalculator.Add("7,2,5");
            Assert.IsTrue(total == 14);
        }


        [Test]
        public void StringCalculator_When3Digits_SumOfValuesReturnedWilBe12()
        {
            var stringCalculator = new StringCalculator();
            var total = stringCalculator.Add("7,0,5");
            Assert.IsTrue(total == 12);
        }
        [Test]
        public void StringCalculator_WhenNewLine_StringIsParsedCorrectly()
        {
            var stringCalculator = new StringCalculator();
            var total = stringCalculator.Add("7,0,5\n1");
            Assert.IsTrue(total == 13);
        }

        [TestCase("7\n0, 5\n1, 4, 5", 22)]
        [TestCase("0, 4\n4, 5,0", 13)]
        [TestCase("//;\n0;4\n4, 5,0,10", 23)]
        public void StringCalculator_WhenNewLinetimetwo_StringIsParsedCorrectly(string numbers, int expectedResult)
        {
            var stringCalculator = new StringCalculator();
            var total = stringCalculator.Add(numbers);
            Assert.IsTrue(total == expectedResult);
        }
    }

}
