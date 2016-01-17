using GraphicalEditor.Validators;
using NUnit.Framework;

namespace GraphicalEditorTests.Validators
{
    [TestFixture]
    public class ShowValidatorTests
    {
        private ShowValidator _showValidator;

        [SetUp]
        public void Setup()
        {
            _showValidator = new ShowValidator();
        }

        [TearDown]
        public void Teardown()
        {
            _showValidator = null;
        }

        [TestCase("S")]
        [TestCase("s")]
        public void ShouldReturnTrueIfOnlyArgumentIsS(string line)
        {
            var splitLine = GetSplitLine(line);
            var result = _showValidator.IsValid(splitLine);

            Assert.That(result, Is.EqualTo(true));
        }

        [TestCase("S 1")]
        [TestCase("S 1 2")]
        [TestCase("S 1 2 3")]
        public void ShouldReturnFalseIfArgumentLengthIsNotExactly1(string line)
        {
            var splitLine = GetSplitLine(line);
            var result = _showValidator.IsValid(splitLine);

            Assert.That(result, Is.EqualTo(false));
        }

        [TestCase("X")]
        public void ShouldReturnFalseIfArgumentIsnotAnS(string line)
        {
            var splitLine = GetSplitLine(line);
            var result = _showValidator.IsValid(splitLine);

            Assert.That(result, Is.EqualTo(false));
        }

        private static string[] GetSplitLine(string line)
        {
            return line.Split(' ');
        }
    }
}
