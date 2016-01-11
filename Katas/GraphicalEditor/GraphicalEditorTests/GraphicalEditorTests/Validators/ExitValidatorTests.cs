using GraphicalEditor.Validators;
using NUnit.Framework;

namespace GraphicalEditorTests.Validators
{
    [TestFixture]
    public class ExitValidatorTests
    {
        [TestCase("X")]
        [TestCase("x")]
        [TestCase(" x ")]
        public void ShouldReturnTrueIfOnlyArgumentIsX(string line)
        {
            var spltLine = line.Trim().Split(' ');
            var validator = new ExitValidator();

            var result = validator.IsValid(spltLine);

            Assert.That(result, Is.EqualTo(true));
        }

        [TestCase("Y")]
        [TestCase("5")]
        public void ShouldReturnFalseIfOnlyArgumentIsNotX(string line)
        {
            var spltLine = line.Split(' ');
            var validator = new ExitValidator();

            var result = validator.IsValid(spltLine);

            Assert.That(result, Is.EqualTo(false));
        }

        [TestCase("X 1")]
        [TestCase("X 1 2")]
        [TestCase("X 1 2 3")]
        public void ShouldReturnFalseIfTheNumberOfArgumentsIsNotOne(string line)
        {
            var splitLine = line.Split(' ');
            var validator = new ExitValidator();

            var result = validator.IsValid(splitLine);

            Assert.That(result, Is.EqualTo(false));
        }
    }
}
