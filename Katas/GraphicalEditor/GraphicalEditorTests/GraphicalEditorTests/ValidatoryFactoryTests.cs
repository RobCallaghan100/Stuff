namespace GraphicalEditorTests
{
    using GraphicalEditor;
    using GraphicalEditor.Validators;
    using NUnit.Framework;

    [TestFixture]
    public class ValidatoryFactoryTests
    {
        [Test]
        public void ShouldReturnCorrectValidatorGivenCommandType()
        {
            var validatorFactory = new ValidatorFactory();

            var validator = validatorFactory.GetValidator(CommandType.Exit);

            Assert.IsInstanceOf<ExitValidator>(validator);
        }

        // TODO: Add other factories to test as they are created
    }
}
