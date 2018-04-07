using System;
using NUnit.Framework;
using StringCalculatorKata;

namespace StringCalculatorTests
{
    [TestFixture]
    public class UnitTest1
    {
        private StringCalculator stringCalculator;

        [SetUp]
        public void StringCalculator()
        {
            stringCalculator=new StringCalculator();

        }

        [Test]
        public void add_WhenEmpty_ReturnZero()
        {
            var total = stringCalculator.Add("");
            Assert.IsTrue(total == 0);
        }

        [Test]
        public void add_When1Digit_ReturnValue()
        {
            var total = stringCalculator.Add("7");
            Assert.IsTrue(total == 7);
        }

        [Test]
        public void add_When2Digit_SumOfValuesReturnedWillBe9()
        {
            var total = stringCalculator.Add("7,2");
            Assert.IsTrue(total == 9);
        }

        [Test]
        public void add_When3Digits_SumOfValuesReturnedWilBe14()
        {
            var total = stringCalculator.Add("7,2,5");
            Assert.IsTrue(total == 14);
        }


        [Test]
        public void add_When3Digits_SumOfValuesReturnedWilBe12()
        {
            var total = stringCalculator.Add("7,0,5");
            Assert.IsTrue(total == 12);
        }
        [Test]
        public void add_WhenNewLine_StringIsParsedCorrectly()
        {
            var total = stringCalculator.Add("7,0,5\n1");
            Assert.IsTrue(total == 13);
        }


        [Test]
        public void add_WhenCustomDelimiter_StringIsParsedCorrectly()
        {
            var total = stringCalculator.Add("//;\n0;4\n4;5;0;10");
            Assert.IsTrue(total == 23);
        }


        [TestCase("7\n0, 5\n1, 4, 5", 22)]
        [TestCase("0, 4\n4, 5,0", 13)]
        [TestCase("//;\n0;4\n4, 5,0,10", 23)]
        public void add_WhenMixingAndMatchingDelimiters_StringIsParsedCorrectly(string numbers, int expectedResult)
        {
            var total = stringCalculator.Add(numbers);
            Assert.IsTrue(total == expectedResult);
        }

        [Test]
        public void add_whenNegativeNumnber_exceptionisthrownwithMessageequaltovalueofnegativenumber()
        {

            var exception=Assert.Throws<ApplicationException>(() => { stringCalculator.Add("7\n0, 5\n1, -1, 5"); });

            Assert.AreEqual(exception.Message,"-1");
        }

        [TestCase("-1, 4\n4, -5,0", "-1,-5")]
        [TestCase("//;\n-6;4\n4, 5,-4,10", "-6,-4")]
        public void add_whenNegativeNumnbesr_exceptionisthrownwithMessageContainingAllTheNegativeNumbers(string numbers, string expectedResult)
        {

            var exception = Assert.Throws<ApplicationException>(() => { stringCalculator.Add("7\n0, 5\n1, -1, 5"); });

            Assert.AreEqual(exception.Message, "-1");
        }

        [TestCase("7\n0, 5\n1, 4, 5, 22\n10005",44)]
        [TestCase("2004\n0, 5\n1, 1004, 5, 22\n10005", 33)]
        [TestCase("2004\n0, 5\n1, 1004, 5, 22\n10001", 33)]
        public void add_WhenNumberisGreaterThan1000_IgnoreNumbersGreaterthan10000(string numbers, int expectedResult)
        {
            var total = stringCalculator.Add(numbers);
            Assert.IsTrue(total == expectedResult);
        }

    }

}
