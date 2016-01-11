using GraphicalEditor.Validators;
using NUnit.Framework;

namespace GraphicalEditorTests.Validators
{
    [TestFixture]
    public class CreateValidatorTests
    {
        [TestCase(false, new string[] { "I"})]
        [TestCase(false, new string[] { "I 1"})]
        [TestCase(false, new string[] { "I 1 2 3"})]
        [TestCase(false, new string[] { "I 1 2 3 4"})]
        public void ShouldReturnFalseIfThereAreNotExactlyThreeArguments(bool expectedResult, string[] args)
        {
            var createValidator = new CreateValidator();

            var result = createValidator.IsValid(args);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

    }
}
