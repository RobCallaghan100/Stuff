namespace GraphicalEditorTests
{
    using System;
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

        [TestCase(0, 1)]
        [TestCase(-1, 1)]
        [TestCase(251, 1)]
        public void ShouldRaiseExceptionIfMIsNegativeOrZeroOrOver250(int m, int n)
        {
            var image = new Image();

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => image.Create(m, n));

            Assert.That(exception.Message, Is.EqualTo("m should be between 1 to 250\r\nParameter name: m"));
        }

        [TestCase(1, 0)]
        [TestCase(1, -1)]
        [TestCase(1, 251)]
        public void ShouldRaiseExceptionIfNIsNegativeOrZeroOrOver250(int m, int n)
        {
            var image = new Image();

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => image.Create(m, n));

            Assert.That(exception.Message, Is.EqualTo("n should be between 1 to 250\r\nParameter name: n"));
        }

        // check that m and n are not out of range
        // check for null values??
    }
}
