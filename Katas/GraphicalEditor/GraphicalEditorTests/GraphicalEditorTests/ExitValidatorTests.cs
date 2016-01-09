namespace GraphicalEditorTests
{
    using GraphicalEditor;
    using NUnit.Framework;

    [TestFixture]
    public class ExitValidatorTests
    {
        [TestCase("X")]
        [TestCase("x")]
        [TestCase(" x ")]
        public void ShouldReturnTrueIfOnlyArgumentIsX(string line)
        {
            var spltLine = line.Split(' ');
            var validator = new ExitValidator();

            var result = validator.IsValid(spltLine);

            Assert.That(result, Is.EqualTo(true));
        }

        [TestCase("Y")]
        public void ShouldReturnFalseIfOnlyArgumentIsNotX(string line)
        {
            var spltLine = line.Split(' ');
            var validator = new ExitValidator();

            var result = validator.IsValid(spltLine);

            Assert.That(result, Is.EqualTo(false));
        }
    }
}
