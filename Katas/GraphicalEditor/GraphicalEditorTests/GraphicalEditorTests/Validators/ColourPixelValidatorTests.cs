using GraphicalEditor.Validators;
using NUnit.Framework;

namespace GraphicalEditorTests.Validators
{
    [TestFixture]
    public class ColourPixelValidatorTests
    {
        private ColourPixelValidator _colourPixelValidator;

        [SetUp]
        public void Setup()
        {
            _colourPixelValidator = new ColourPixelValidator();
        }

        [TearDown]
        public void Teardown()
        {
            _colourPixelValidator = null;
        }

        [TestCase(false, new[] { "L" })]
        [TestCase(false, new[] { "L", "1" })]
        [TestCase(false, new[] { "L", "1", "2" })]
        [TestCase(false, new[] { "L", "1", "2", "C", "A" })]
        public void ShouldReturnFalseIfThereAreNotExactlyFourArguments(bool expectedResult, string[] args)
        {
            var result = _colourPixelValidator.IsValid(args);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ShouldReturnFalseIfIfFirstParameterIsNotL()
        {
            var result = _colourPixelValidator.IsValid(new[] {"X", "1", "2", "A"});

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void ShouldReturnFalseIfSecondParameterIsNotAnInt()
        {
            var result = _colourPixelValidator.IsValid(new[] { "L", "X", "2", "A" });

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void ShouldReturnFalseIfThirdParameterIsNotAnInt()
        {
            var result = _colourPixelValidator.IsValid(new[] { "L", "1", "Y", "A" });

            Assert.That(result, Is.EqualTo(false));
        }

     [Test]
        public void ShouldReturnTrueIfPassedExpectedFormat()
        {
            var result = _colourPixelValidator.IsValid(new[] { "L", "1", "2", "A" });

            Assert.That(result, Is.EqualTo(true));
        }
        
        [TestCase("0")]
        [TestCase("251")]
        public void ShouldReturnFalseIfSecondArgumentIsNotBetween1And250(string arg)
        {
            var result = _colourPixelValidator.IsValid(new[] { "L", arg, "1", "A" });

            Assert.That(result, Is.False);
        }

        [TestCase("0")]
        [TestCase("251")]
        public void ShouldReturnFalseIfThirdArgumentIsNotBetween1And250(string arg)
        {
            var result = _colourPixelValidator.IsValid(new[] { "L", "1", arg, "A" });

            Assert.That(result, Is.False);
        }
    }
}
