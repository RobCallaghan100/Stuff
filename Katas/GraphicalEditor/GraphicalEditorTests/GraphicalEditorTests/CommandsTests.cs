namespace GraphicalEditorTests
{
    using GraphicalEditor;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class CommandsTests
    {
        private Mock<IImage> _mockImage;

        [SetUp]
        public void Setup()
        {
            _mockImage = new Mock<IImage>();
            
        }

        [TearDown]
        public void Teardown()
        {
            _mockImage = null;
        }

        [Test]
        public void ShouldExitWhenXPressed()
        {
            var command = new Command(_mockImage.Object);
            command.Input("M");

            Assert.That(command.Image, Is.Null);
        }

        [Test]
        public void ShouldCallCreateOnImageObjectWhenPassedIMN()
        {
            _mockImage.Setup(i => i.Create(It.IsAny<int>(), It.IsAny<int>()));
            var command = new Command(_mockImage.Object);

            command.Input("I 1 1");

            _mockImage.Verify(i => i.Create(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        // TODO: add validator class to check that inputs are in correct format
    }
}
