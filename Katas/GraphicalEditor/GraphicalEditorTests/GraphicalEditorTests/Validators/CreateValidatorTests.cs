using GraphicalEditor.Validators;
using NUnit.Framework;

namespace GraphicalEditorTests.Validators
{
    [TestFixture]
    public class CreateValidatorTests
    {
        [Test]
        public void ShouldReturnFalseIfThereAreNotExactlyThreeArguments()
        {
            var createValidator = new CreateValidator();

            var result = createValidator.IsValid(new[] {"I"});

            Assert.That(result, Is.EqualTo(false));
        }

    }
}
