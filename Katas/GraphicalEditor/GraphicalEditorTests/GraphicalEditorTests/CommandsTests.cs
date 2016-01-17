﻿namespace GraphicalEditorTests
{
    using GraphicalEditor;
    using GraphicalEditor.Interfaces;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class CommandsTests
    {
        private Mock<IImage> _mockImage;
        private Mock<ICommandArgumentParser> _mockCommandArgumentParserMock;

        [SetUp]
        public void Setup()
        {
            _mockImage = new Mock<IImage>();
            _mockCommandArgumentParserMock = new Mock<ICommandArgumentParser>();
        }

        [TearDown]
        public void Teardown()
        {
            _mockImage = null;
            _mockCommandArgumentParserMock = null;
        }

        [Test]
        public void ShouldExitWhenXPressed()
        {
            var command = new Command(_mockImage.Object, _mockCommandArgumentParserMock.Object);
            command.Input("X");

            Assert.That(command.Image, Is.Null);
        }

        [TestCase("I 1 1", 1, 1)]
        [TestCase("I 250 250", 250, 250)]
        public void ShouldCallCreateOnImageObjectWhenPassedIMN(string input, int m, int n)
        {
            _mockImage.Setup(i => i.Create(It.IsAny<int>(), It.IsAny<int>()));
            _mockCommandArgumentParserMock.Setup(cap => cap.CommandType).Returns(CommandType.Create);
            _mockCommandArgumentParserMock.Setup(cap => cap.M).Returns(m);
            _mockCommandArgumentParserMock.Setup(cap => cap.N).Returns(n);
            var command = new Command(_mockImage.Object, _mockCommandArgumentParserMock.Object);

            command.Input(input);

            _mockImage.Verify(i => i.Create(m, n), Times.Once);
        }

        // TODO: pass in empty string and  string with only spaces
        // TODO: add validator class to check that inputs are in correct format
    }
}
