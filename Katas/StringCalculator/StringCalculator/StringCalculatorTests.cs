using NUnit.Framework;

namespace StringCalculator
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private StringCalculator _stringCalculator;

        [SetUp]
        public void Setup()
        {
            _stringCalculator = new StringCalculator();
        }

        [TearDown]
        public void Teardown()
        {
            _stringCalculator = null;
        }

        [Test]
        public void ShouldReturnZeroForAnEmptyString()
        {
            var result = _stringCalculator.Add("");

            Assert.That(result, Is.EqualTo(0));
        }

        [TestCase("0", 0)]
        [TestCase("1", 1)]
        [TestCase("5", 5)]
        [TestCase("9", 9)]
        public void ShouldReturnValueForSingleNumber(string numbers, int expectedValue)
        {
            var result = _stringCalculator.Add(numbers);

            Assert.That(result, Is.EqualTo(expectedValue));
        }

        [TestCase("0,0", 0)]
        [TestCase("0,1", 1)]
        [TestCase("1,1", 2)]
        [TestCase("21,9", 30)]
        [TestCase("32,32", 64)]
        public void ShouldReturnSumForTwoCommaDelimitedNumbers(string numbers, int expectedResult)
        {
            var result = _stringCalculator.Add(numbers);

            Assert.That(result, Is.EqualTo(expectedResult));
        }


        /*
        check that character is in fact an int in single cases
        */
    }
}
