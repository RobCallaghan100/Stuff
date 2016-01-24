using GraphicalEditor.Validators;
using NUnit.Framework;

namespace GraphicalEditorTests.Validators
{
    [TestFixture]
    public class HorizontalSegmentValidatorTests
    {
        private HorizontalSegmentValidator _horizontalSegmentValidator;

        [SetUp]
        public void Setup()
        {
            _horizontalSegmentValidator = new HorizontalSegmentValidator();
        }

        [TearDown]
        public void Teardown()
        {
            _horizontalSegmentValidator = null;
        }


        [TestCase(false, new[] { "H" })]
        [TestCase(false, new[] { "H", "1" })]
        [TestCase(false, new[] { "H", "1", "2" })]
        [TestCase(false, new[] { "H", "1", "2", "3" })]
        [TestCase(false, new[] { "H", "1", "2", "3", "A", "A" })]
        public void ShouldReturnFalseIfThereAreNotExactlyFiveArguments(bool expectedResult, string[] args)
        {
            var result = _horizontalSegmentValidator.IsValid(args);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ShouldReturnFalseIfIfFirstParameterIsNotH()
        {
            var result = _horizontalSegmentValidator.IsValid(new[] { "X", "1", "2", "3", "A" });

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void ShouldReturnFalseIfSecondParameterIsNotAnInt()
        {
            var result = _horizontalSegmentValidator.IsValid(new[] { "H", "X", "2", "3", "A" });

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void ShouldReturnFalseIfThirdParameterIsNotAnInt()
        {
            var result = _horizontalSegmentValidator.IsValid(new[] { "H", "1", "X", "3", "A" });

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void ShouldReturnFalseIfFourthParameterIsNotAnInt()
        {
            var result = _horizontalSegmentValidator.IsValid(new[] { "H", "1", "2", "X", "A" });

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void ShouldReturnTrueIfPassedExpectedFormat()
        {
            var result = _horizontalSegmentValidator.IsValid(new[] { "H", "1", "2", "3", "A" });

            Assert.That(result, Is.EqualTo(true));
        }

        [TestCase("0")]
        [TestCase("251")]
        public void ShouldReturnFalseIfSecondArgumentIsNotBetween1And250(string arg)
        {
            var result = _horizontalSegmentValidator.IsValid(new[] { "H", arg, "2", "3", "A" });

            Assert.That(result, Is.False);
        }

        [TestCase("0")]
        [TestCase("251")]
        public void ShouldReturnFalseIfThirdArgumentIsNotBetween1And250(string arg)
        {
            var result = _horizontalSegmentValidator.IsValid(new[] { "H", "1", arg, "3", "A" });

            Assert.That(result, Is.False);
        }

        [TestCase("0")]
        [TestCase("251")]
        public void ShouldReturnFalseIfFourthArgumentIsNotBetween1And250(string arg)
        {
            var result = _horizontalSegmentValidator.IsValid(new[] { "H", "1", "2", arg, "A" });

            Assert.That(result, Is.False);
        }

    }
}
