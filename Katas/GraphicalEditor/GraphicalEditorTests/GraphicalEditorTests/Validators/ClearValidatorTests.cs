namespace GraphicalEditorTests.Validators
{
    using GraphicalEditor.Validators;
    using NUnit.Framework;

    [TestFixture]
    public class ClearValidatorTests
    {
        private ClearValidator _clearValidator;

        [SetUp]
        public void Setup()
        {
            _clearValidator = new ClearValidator();
        }

        [TearDown]
        public void Teardown()
        {
            _clearValidator = null;
        }

        [TestCase(true, new[] {"C"})]
        [TestCase(true, new[] {"c "})]
        [TestCase(true, new[] {" C"})]
        public void ShouldReturnTrueIfPassedCOnly(bool expectedResult, string[] args)
        {
            var result = _clearValidator.IsValid(args);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(false, new[] { "C", "1" })]
        [TestCase(false, new[] { "C", "1", "2" })]
        [TestCase(false, new[] { "C", "1", "2", "3" })]
        public void ShouldReturnFalseIfNumberOfArgumentsIsNotOne(bool expectedResult, string[] args)
        {
            var result = _clearValidator.IsValid(args);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
