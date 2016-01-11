using GraphicalEditor.Validators;
using NUnit.Framework;

namespace GraphicalEditorTests.Validators
{
    [TestFixture]
    public class CreateValidatorTests
    {
        private CreateValidator _createValidator;

        [SetUp]
        public void Setup()
        {
            _createValidator = new CreateValidator();
        }

        [TearDown]
        public void Teardown()
        {
            _createValidator = null;
        }

        [TestCase(false, new string[] { "I"})]
        [TestCase(false, new string[] { "I 1"})]
        [TestCase(false, new string[] { "I 1 2 3"})]
        [TestCase(false, new string[] { "I 1 2 3 4"})]
        public void ShouldReturnFalseIfThereAreNotExactlyThreeArguments(bool expectedResult, string[] args)
        {
            var result = _createValidator.IsValid(args);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void ShouldReturnFalseIfSecondArgumentIsNotAnInt()
        {
            var result = _createValidator.IsValid(new []{ "I", "D", "1" });

            Assert.That(result, Is.False);
        }

        [Test]
        public void ShouldReturnFalseIfThirdArgumentIsNotAnInt()
        {
            var result = _createValidator.IsValid(new[] { "I", "1", "Q" });

            Assert.That(result, Is.False);
        }

        /*
        check that I is first arg
        check that args 2 and 3 are ints
        check that args 2 and 3 are between 1 and 250
        check true if I 1 2 and a couple of other examples
        */

    }
}
