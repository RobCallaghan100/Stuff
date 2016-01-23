﻿using GraphicalEditor.Interfaces;
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
            _mockRangeValidator.Setup(v => v.IsInRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            var image = new Image(_mockRangeValidator.Object);
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => image.Create(m, n));

            Assert.That(exception.Message, Is.EqualTo("m should be between 1 to 250\r\nParameter name: m"));
        }

        [TestCase(1, 0)]
        [TestCase(1, -1)]
        [TestCase(1, 251)]
        public void ShouldRaiseExceptionIfNIsNegativeOrZeroOrOver250(int m, int n)
        {
            _mockRangeValidator = new Mock<IRangeValidator>();
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

        [TestCase(0, 1, 'A')]
        [TestCase(-1, 1, 'A')]
        [TestCase(251, 1, 'A')]
        public void ShouldRaiseExceptionIfXIsNegativeOrZeroOrOver250(int x, int y, char pixel)
        {
            _mockRangeValidator.Setup(v => v.IsInRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            var image = new Image(_mockRangeValidator.Object);
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => image.ColourPixel(x, y, pixel));

            Assert.That(exception.Message, Is.EqualTo("x should be between 1 and 250\r\nParameter name: x"));
        }

        [TestCase(1, 0, 'A')]
        [TestCase(1, -1, 'A')]
        [TestCase(1, 251, 'A')]
        public void ShouldRaiseExceptionIfYIsNegativeOrZeroOrOver250(int x, int y, char pixel)
        {
            _mockRangeValidator.Setup(v => v.IsInRange(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            var image = new Image(_mockRangeValidator.Object);
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => image.ColourPixel(x, y, pixel));

            Assert.That(exception.Message, Is.EqualTo("y should be between 1 and 250\r\nParameter name: y"));
        }

       // TODO: check x is not greater than m
       // TODO: check y is not greater than n

        // TODO: check for null values??
    }
}
