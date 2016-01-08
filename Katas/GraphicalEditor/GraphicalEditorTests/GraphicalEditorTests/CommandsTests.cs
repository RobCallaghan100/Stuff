namespace GraphicalEditorTests
{
    using GraphicalEditor;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class CommandsTests
    {
        [Test]
        public void ShouldExitWhenXPressed()
        {
            var mockImage = new Mock<IImage>();
            var command = new Command(mockImage.Object);

            command.Input("X");

            Assert.That(command.Image, Is.Null);
        }

        [Test]
        public void ShouldCallCreateOnImageObjectWhenPassedIMN()
        {
            var mockImage = new Mock<IImage>();
            mockImage.Setup(i => i.Create(It.IsAny<int>(), It.IsAny<int>()));
            var command = new Command(mockImage.Object);

            command.Input("I 1 1");

            mockImage.Verify(i => i.Create(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }

        // TODO: add validator class to check that inputs are in correct format
    }
}
