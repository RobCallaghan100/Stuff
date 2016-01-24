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

        [TestCase(false, new[] { "I"})]
        [TestCase(false, new[] { "I 1"})]
        [TestCase(false, new[] { "I 1 2 3"})]
        [TestCase(false, new[] { "I 1 2 3 4"})]
        public void ShouldReturnFalseIfThereAreNotExactlyThreeArguments(bool expectedResult, string[] args)
        {
            var result = _createValidator.IsValid(args);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase("L")]
        [TestCase("N")]
        public void ShouldReturnFalseIfFirstParameterIsNotI(string firstArg)
        {
            var result = _createValidator.IsValid(new[] { firstArg, "1", "2" });

            Assert.That(result, Is.False);
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

        [TestCase("0")]
        [TestCase("251")]
        public void ShouldReturnFalseIfSecondArgumentIsNotBetween1And250(string arg)
        {
            var result = _createValidator.IsValid(new[] { "I", arg, "1" });

            Assert.That(result, Is.False);
        }

        [TestCase("0")]
        [TestCase("251")]
        public void ShouldReturnFalseIfThirdArgumentIsNotBetween1And250(string arg)
        {
            var result = _createValidator.IsValid(new[] { "I", "1", arg });

            Assert.That(result, Is.False);
        }

        [TestCase("1", "1")]
        [TestCase("250", "250")]
        public void ShouldReturnTrueIfPassedImn(string m, string n)
        {
            var result = _createValidator.IsValid(new[] { "I", m, n });

            Assert.That(result, Is.True);
        }

        /*
        check true if I 1 2 and a couple of other examples
        */

    }
}
