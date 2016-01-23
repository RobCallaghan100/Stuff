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

        [TestCase(true, new string[] {"C"})]
        [TestCase(true, new string[] {"c "})]
        [TestCase(true, new string[] {" C"})]
        public void ShouldReturnTrueIfPassedCOnly(bool expectedResult, string[] args)
        {
            var result = _clearValidator.IsValid(args);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase(false, new string[] { "C", "1" })]
        [TestCase(false, new string[] { "C", "1", "2" })]
        [TestCase(false, new string[] { "C", "1", "2", "3" })]
        public void ShouldReturnFalseIfNumberOfArgumentsIsNotOne(bool expectedResult, string[] args)
        {
            var result = _clearValidator.IsValid(args);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
