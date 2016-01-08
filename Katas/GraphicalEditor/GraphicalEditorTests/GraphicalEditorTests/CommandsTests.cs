namespace GraphicalEditorTests
{
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
    }

    public interface IImage
    {
    }
}
