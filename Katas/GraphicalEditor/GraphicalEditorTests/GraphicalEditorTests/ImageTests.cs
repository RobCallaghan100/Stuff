namespace GraphicalEditorTests
{
    using System;
    using GraphicalEditor;
    using NUnit.Framework;

    [TestFixture]
    public class ImageTests
    {
        private Image _image;

        [SetUp]
        public void Setup()
        {
            _image = new Image();
        }

        [TearDown]
        public void Teardown()
        {
            _image = null;
        }

        [TestCase(1, 1)]
        [TestCase(250, 250)]
        public void ShouldSetSizeOfMAndNWhenCreateMethodCalledWithMAndN(int m, int n)
        {
            _image.Create(m, n);

            Assert.That(_image.M, Is.EqualTo(m));
            Assert.That(_image.N, Is.EqualTo(n));
        }

        [TestCase(0, 1)]
        [TestCase(-1, 1)]
        [TestCase(251, 1)]
        public void ShouldRaiseExceptionIfMIsNegativeOrZeroOrOver250(int m, int n)
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => _image.Create(m, n));

            Assert.That(exception.Message, Is.EqualTo("m should be between 1 to 250\r\nParameter name: m"));
        }

        [TestCase(1, 0)]
        [TestCase(1, -1)]
        [TestCase(1, 251)]
        public void ShouldRaiseExceptionIfNIsNegativeOrZeroOrOver250(int m, int n)
        {
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => _image.Create(m, n));

            Assert.That(exception.Message, Is.EqualTo("n should be between 1 to 250\r\nParameter name: n"));
        }

        [TestCase(1, 1, "O")]
        [TestCase(5, 5, "OOOOO\r\nOOOOO\r\nOOOOO\r\nOOOOO\r\nOOOOO")]
        public void ShouldShowAllPixelsAsWhiteOnCreate(int m, int n, string expectedResult)
        {
            _image.Create(m, n);

            Assert.That(_image.ToString(), Is.EqualTo(expectedResult));
        }

        [Test]
        public void ShouldShowImageWhenShowMethodCalled()
        {
            _image.Create(1,1);

            var result = _image.Show();

            Assert.That(result, Is.EqualTo("O"));
        }

        // TODO: check for null values??
    }
}
