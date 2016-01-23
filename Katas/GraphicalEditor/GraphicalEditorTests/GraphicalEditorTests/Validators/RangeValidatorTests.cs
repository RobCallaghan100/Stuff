using GraphicalEditor.Validators;
using NUnit.Framework;

namespace GraphicalEditorTests.Validators
{
    [TestFixture]
    public class RangeValidatorTests
    {
        [TestCase(1,1,1)]
        [TestCase(1,250, 1)]
        [TestCase(1,250, 250)]
        public void ShouldReturnTrueIfValueBetweenStartAndEndRange(int startRange, int endRange, int value)
        {
            var rangeValidator = new RangeValidator();

            var result = rangeValidator.IsInRange(startRange, endRange, value);

            Assert.That(result, Is.True);
        }

        [TestCase(1, 1, 0)]
        [TestCase(1, 250, 0)]
        [TestCase(1, 250, 251)]
        public void ShouldReturnFalseIfValueOutsideStartAndEndRange(int startRange, int endRange, int value)
        {
            var rangeValidator = new RangeValidator();

            var result = rangeValidator.IsInRange(startRange, endRange, value);

            Assert.That(result, Is.False);
        }
    }
}
