namespace GraphicalEditorTests
{
    using GraphicalEditor;
    using NUnit.Framework;

    [TestFixture]
    public class ImageTests
    {   
        [TestCase(1, 1)]
        [TestCase(250, 250)]
        public void ShouldSetSizeOfMAndNWhenCreateMethodCalledWithMAndN(int m, int n)
        {
            var image = new Image();

            image.Create(m, n);

            Assert.That(image.M, Is.EqualTo(m));
            Assert.That(image.N, Is.EqualTo(n));
        }

        // check that m and n are not out of range
    }
}
