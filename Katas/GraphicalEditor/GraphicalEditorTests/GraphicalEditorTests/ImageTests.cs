namespace GraphicalEditorTests
{
    using GraphicalEditor;
    using NUnit.Framework;

    [TestFixture]
    public class ImageTests
    {   
        [Test]
        public void ShouldSetSizeOfMAndNWhenCreateMethodCalledWithMAndN()
        {
            var image = new Image();

            image.Create(1, 1);

            Assert.That(image.M, Is.EqualTo(1));
            Assert.That(image.N, Is.EqualTo(1));
        }
    }
}
