using GraphicalEditor.Validators;
using NUnit.Framework;

namespace GraphicalEditorTests.Validators
{
    [TestFixture]
    public class VerticalSegmentValidatorTests
    {
        private VerticalSegmentValidator _verticalSegmentValidator;

        [SetUp] 
        public void Setup()
        {
            _verticalSegmentValidator = new VerticalSegmentValidator();
        }

        [TearDown]
        public void Teardown()
        {
            _verticalSegmentValidator = null;
        }

        [TestCase(false, new string[] { "V" })]
        [TestCase(false, new string[] { "V", "1" })]
        [TestCase(false, new string[] { "V", "1", "2" })]
        [TestCase(false, new string[] { "V", "1", "2", "3" })]
        [TestCase(false, new string[] { "V", "1", "2", "3", "A", "A" })]
        public void ShouldReturnFalseIfThereAreNotExactlyFiveArguments(bool expectedResult, string[] args)
        {
            var result = _verticalSegmentValidator.IsValid(args);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ShouldReturnFalseIfIfFirstParameterIsNotV()
        {
            var result = _verticalSegmentValidator.IsValid(new string[] {"X", "1", "2", "3", "A"});

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void ShouldReturnFalseIfSecondParameterIsNotAnInt()
        {
            var result = _verticalSegmentValidator.IsValid(new string[] { "V", "X", "2", "3", "A" });

            Assert.That(result, Is.EqualTo(false));
        }
//
//        [Test]
//        public void ShouldReturnFalseIfThirdParameterIsNotAnInt()
//        {
//            var result = _verticalSegmentValidator.IsValid(new string[] { "L", "1", "Y", "A" });
//
//            Assert.That(result, Is.EqualTo(false));
//        }
//
//     [Test]
//        public void ShouldReturnTrueIfPassedExpectedFormat()
//        {
//            var result = _verticalSegmentValidator.IsValid(new string[] { "L", "1", "2", "A" });
//
//            Assert.That(result, Is.EqualTo(true));
//        }
//        
//        [TestCase("0")]
//        [TestCase("251")]
//        public void ShouldReturnFalseIfSecondArgumentIsNotBetween1And250(string arg)
//        {
//            var result = _verticalSegmentValidator.IsValid(new[] { "L", arg, "1", "A" });
//
//            Assert.That(result, Is.False);
//        }
//
//        [TestCase("0")]
//        [TestCase("251")]
//        public void ShouldReturnFalseIfThirdArgumentIsNotBetween1And250(string arg)
//        {
//            var result = _verticalSegmentValidator.IsValid(new[] { "L", "1", arg, "A" });
//
//            Assert.That(result, Is.False);
//        }

    }
}
