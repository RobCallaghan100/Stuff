using GraphicalEditor.Interfaces;
using Moq;

namespace GraphicalEditorTests
{
    using System;
    using GraphicalEditor;
    using NUnit.Framework;

    [TestFixture]
    public class ImageTests
    {
        private Mock<IRangeValidator> _mockRangeValidator;

        [SetUp]
        public void Setup()
        {
            _mockRangeValidator = new Mock<IRangeValidator>();
        }

        [TearDown]
        public void Teardown()
        {
            _mockRangeValidator = null;
        }

        [TestCase(1, 1)]
        [TestCase(250, 250)]
        public void ShouldSetSizeOfMAndNWhenCreateMethodCalledWithMAndN(int m, int n)
        {
            _mockRangeValidator.Setup(v => v.IsInRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            var image = new Image(_mockRangeValidator.Object);

            image.Create(m, n);

            Assert.That(image.M, Is.EqualTo(m));
            Assert.That(image.N, Is.EqualTo(n));
        }

        [TestCase(0, 1)]
        [TestCase(-1, 1)]
        [TestCase(251, 1)]
        public void ShouldRaiseExceptionIfMIsNotInRange(int m, int n)
        {
            _mockRangeValidator.Setup(v => v.IsInRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(false);
            var image = new Image(_mockRangeValidator.Object);
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => image.Create(m, n));

            Assert.That(exception.Message, Is.EqualTo("m should be between 1 to 250\r\nParameter name: m"));
        }

        [TestCase(1, 0)]
        [TestCase(1, -1)]
        [TestCase(1, 251)]
        public void ShouldRaiseExceptionIfNIsNegativeOrZeroOrOver250(int m, int n)
        {
            _mockRangeValidator.SetupSequence(v => v.IsInRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(true).Returns(false);
            var image = new Image(_mockRangeValidator.Object);
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => image.Create(m, n));

            Assert.That(exception.Message, Is.EqualTo("n should be between 1 to 250\r\nParameter name: n"));
        }

        [TestCase(1, 2, "O\r\nO")]
        [TestCase(5, 6, "OOOOO\r\nOOOOO\r\nOOOOO\r\nOOOOO\r\nOOOOO\r\nOOOOO")]
        public void ShouldShowAllPixelsAsWhiteOnCreate(int m, int n, string expectedResult)
        {
            _mockRangeValidator.Setup(v => v.IsInRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            var image = new Image(_mockRangeValidator.Object);
            image.Create(m, n);

            Assert.That(image.ToString(), Is.EqualTo(expectedResult));
        }

        [Test]
        public void ShouldShowImageWhenShowMethodCalled()
        {
            _mockRangeValidator.Setup(v => v.IsInRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            var image = new Image(_mockRangeValidator.Object);
            image.Create(1,1);

            var result = image.Show();

            Assert.That(result, Is.EqualTo("O"));
        }

        [TestCase(1, 1, 'A', "A")]
        [TestCase(5, 6, 'A', "OOOOO\r\nOOOOO\r\nOOOOO\r\nOOOOO\r\nOOOOO\r\nOOOOA")]
        public void ShouldColourPixelWhenColourPixelCalled(int x, int y, char pixel, string output)
        {
            _mockRangeValidator.Setup(v => v.IsInRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            var image = new Image(_mockRangeValidator.Object);
            image.Create(x, y);

            image.ColourPixel(x, y, pixel);

            var result = image.Show();
            Assert.That(result, Is.EqualTo(output));
        }

        [TestCase(1, 0, 'A')]
        [TestCase(1, -1, 'A')]
        [TestCase(1, 251, 'A')]
        public void ShouldRaiseExceptionIfIsInRangeReturnsFalseForYWhenCallingColourPixel(int x, int y, char pixel)
        {
            _mockRangeValidator.SetupSequence(v => v.IsInRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(true).Returns(false);
            var image = new Image(_mockRangeValidator.Object);
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => image.ColourPixel(x, y, pixel));

            Assert.That(exception.Message, Is.EqualTo("y should be between 1 and n\r\nParameter name: y"));
        }

        [Test]
        public void ShouldRaiseExceptionIfIsInRangeReturnsFalseForXWhenCallingColourPixel()
        {
            _mockRangeValidator.SetupSequence(v => v.IsInRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(false).Returns(false);
            var image = new Image(_mockRangeValidator.Object);
            var exception = Assert.Throws<ArgumentOutOfRangeException>(
                () => image.ColourPixel(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<char>()));

            Assert.That(exception.Message, Is.EqualTo("x should be between 1 and m\r\nParameter name: x"));
        }

        [Test]
        public void ShouldShowImageAsAllOsAfterCallingClear()
        {
            _mockRangeValidator.SetupSequence(v => v.IsInRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(true).Returns(true).Returns(true).Returns(true);
            var image = new Image(_mockRangeValidator.Object);
            image.Create(5, 6);
            image.ColourPixel(1, 1, 'A');
            Assert.That(image.Show(), Is.EqualTo("AOOOO\r\nOOOOO\r\nOOOOO\r\nOOOOO\r\nOOOOO\r\nOOOOO"));

            image.Clear();
            Assert.That(image.Show(), Is.EqualTo("OOOOO\r\nOOOOO\r\nOOOOO\r\nOOOOO\r\nOOOOO\r\nOOOOO"));
        }

        [TestCase(1, 1, 6, 'A', "AOOOO\r\nAOOOO\r\nAOOOO\r\nAOOOO\r\nAOOOO\r\nAOOOO")] 
        [TestCase(5, 2, 5, 'C', "OOOOO\r\nOOOOC\r\nOOOOC\r\nOOOOC\r\nOOOOC\r\nOOOOO")] 
        public void ShouldColourVerticalSegmentWhenVerticalSegmentCalled(int x, int y1, int y2, char colour, string output)
        {
            _mockRangeValidator.Setup(v => v.IsInRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            var image = new Image(_mockRangeValidator.Object);
            image.Create(5, 6);

            image.VerticalSegment(x, y1, y2, colour);

            var result = image.Show();  
            Assert.That(result, Is.EqualTo(output));
        }

        // check that x is in range
        // check that y1is in range 
        // check that y2 is in range

        [Test()]
        public void ShouldRaiseExceptionIfInRangeReturnsFalseForX()
        {
            _mockRangeValidator.SetupSequence(v => v.IsInRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(false);
            var image = new Image(_mockRangeValidator.Object);
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => image.VerticalSegment(0, 5, 6, 'A'));

            Assert.That(exception.Message, Is.EqualTo("x should be between 1 and m\r\nParameter name: x"));
        }

        [Test()]
        public void ShouldRaiseExceptionIfInRangeReturnsFalseForY1()
        {
            _mockRangeValidator.SetupSequence(v => v.IsInRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(true).Returns(false);
            var image = new Image(_mockRangeValidator.Object);
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => image.VerticalSegment(1, 0, 6, 'A'));

            Assert.That(exception.Message, Is.EqualTo("y1 should be between 1 and n\r\nParameter name: y1"));
        }

        [Test()]
        public void ShouldRaiseExceptionIfInRangeReturnsFalseForY2()
        {
            _mockRangeValidator.SetupSequence(v => v.IsInRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(true).Returns(true).Returns(false);
            var image = new Image(_mockRangeValidator.Object);
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => image.VerticalSegment(1, 1, 0, 'A'));

            Assert.That(exception.Message, Is.EqualTo("y2 should be between 1 and n\r\nParameter name: y2"));
        }

        //        [TestCase(1, 0, 'A')]
        //        [TestCase(1, -1, 'A')]
        //        [TestCase(1, 251, 'A')]
        //        public void ShouldRaiseExceptionIfIsInRangeReturnsFalseForYWhenCallingColourPixel(int x, int y, char pixel)
        //        {
        //            _mockRangeValidator.SetupSequence(v => v.IsInRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(true).Returns(false);
        //            var image = new Image(_mockRangeValidator.Object);
        //            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => image.ColourPixel(x, y, pixel));
        //
        //            Assert.That(exception.Message, Is.EqualTo("y should be between 1 and n\r\nParameter name: y"));
        //        }

        //        [Test]
        //        public void ShouldRaiseExceptionIfIsInRangeReturnsFalseForXWhenCallingColourPixel()
        //        {
        //            _mockRangeValidator.SetupSequence(v => v.IsInRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(false).Returns(false);
        //            var image = new Image(_mockRangeValidator.Object);
        //            var exception = Assert.Throws<ArgumentOutOfRangeException>(
        //                () => image.ColourPixel(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<char>()));
        //
        //            Assert.That(exception.Message, Is.EqualTo("x should be between 1 and m\r\nParameter name: x"));
        //        }

        // TODO: check for null values??
    }
}
