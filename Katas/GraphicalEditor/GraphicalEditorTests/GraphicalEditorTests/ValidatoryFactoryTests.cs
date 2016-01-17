namespace GraphicalEditorTests
{
    using GraphicalEditor;
    using GraphicalEditor.Validators;
    using NUnit.Framework;

    [TestFixture]
    public class ValidatoryFactoryTests
    {
        [Test]
        public void ShouldReturnExitValidatorGivenCommandTypeExit()
        {
            var validator = ValidatorFactory.GetValidator(CommandType.Exit);

            Assert.IsInstanceOf<ExitValidator>(validator);
        }

        [Test]
        public void ShouldReturnCreateValidatorGivenCommandTypeCreate()
        {
            var validator = ValidatorFactory.GetValidator(CommandType.Create);

            Assert.IsInstanceOf<CreateValidator>(validator);
        }

        // TODO: Add other factories to test as they are created
    }
}
