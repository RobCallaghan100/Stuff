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

        [Test]
        public void ShouldReturnShowValidatorGivenCommandTypeShow()
        {
            var validator = ValidatorFactory.GetValidator(CommandType.Show);

            Assert.IsInstanceOf<ShowValidator>(validator);
        }

        [Test]
        public void ShouldReturnColourPixelValidatorGivenCommandTypeColourPixel()
        {
            var validator = ValidatorFactory.GetValidator(CommandType.ColourPixel);

            Assert.IsInstanceOf<ColourPixelValidator>(validator);
        }
            
        [Test]
        public void ShouldReturnClearValidatorGivenCommandTypeColourPixel()
        {
            var validator = ValidatorFactory.GetValidator(CommandType.Clear);   

            Assert.IsInstanceOf<ClearValidator>(validator);
        }

        [Test]
        public void ShouldReturnVerticalSegmentValidatorGivenCommandTypeVerticalSegment()
        {
            var validator = ValidatorFactory.GetValidator(CommandType.VerticalSegment);

            Assert.IsInstanceOf<VerticalSegmentValidator>(validator);
        }

        [Test]
        public void ShouldReturnHorizontalSegmentValidatorGivenCommandTypeHorizontalSegment()
        {
            var validator = ValidatorFactory.GetValidator(CommandType.HorizontalSegment);

            Assert.IsInstanceOf<HorizontalSegmentValidator>(validator);
        }
    }
}
