using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCalculatorKata;

namespace StringCalculatorTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StringCalculator_WhenEmpty_ReturnZero()
        {
            var stringCalculator = new StringCalculator();
            var total = stringCalculator.Add("");
            Assert.IsTrue(total == 0);
        }
        [TestMethod]
        public void StringCalculator_When1Digit_ReturnValue()
        {
            var stringCalculator = new StringCalculator();
            var total = stringCalculator.Add("7");
            Assert.IsTrue(total == 7);
        }

        [TestMethod]
        public void StringCalculator_When2Digit_SumOfValuesReturnedWillBe9()
        {
            var stringCalculator = new StringCalculator();
            var total = stringCalculator.Add("7,2");
            Assert.IsTrue(total == 9);
        }

        [TestMethod]
        public void StringCalculator_When3Digits_SumOfValuesReturnedWilBe14()
        {
            var stringCalculator = new StringCalculator();
            var total = stringCalculator.Add("7,2,5");
            Assert.IsTrue(total == 14);
        }


        [TestMethod]
        public void StringCalculator_When3Digits_SumOfValuesReturnedWilBe12()
        {
            var stringCalculator = new StringCalculator();
            var total = stringCalculator.Add("7,0,5");
            Assert.IsTrue(total == 12);
        }
        [TestMethod]
        public void StringCalculator_WhenNewLine_StringIsParsedCorrectly()
        {
            var stringCalculator = new StringCalculator();
            var total = stringCalculator.Add("7,0,5\n1");
            Assert.IsTrue(total == 13);
        }

        [TestMethod]
        public void StringCalculator_CustomDelimiters_StringIsParsedCorrectly()
        {
            var stringCalculator = new StringCalculator();
            var total = stringCalculator.Add("//;\n1;2");
            Assert.IsTrue(total == 13);
        }

    }
}
