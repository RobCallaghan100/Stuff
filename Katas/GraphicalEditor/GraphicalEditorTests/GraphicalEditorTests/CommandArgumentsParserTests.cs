using System;

namespace GraphicalEditorTests
{
    using GraphicalEditor;
    using GraphicalEditor.Interfaces;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class CommandArgumentsParserTests
    {
        private Mock<IValidator> _mockValidator;

        [SetUp]
        public void Setup()
        {
            _mockValidator = new Mock<IValidator>();
        }

        [TearDown]
        public void Teardown()
        {
            _mockValidator = null;
        }

        [TestCase("")]
        [TestCase(" ")]
        public void ShouldShowCommandTypeAsNoneIfGivenEmptyString(string line)
        {
            var commandArgumentParser = new CommandArgumentParser(null);
            commandArgumentParser.Parse(line);

            Assert.That(commandArgumentParser.CommandType, Is.EqualTo(CommandType.None));
        }

        [TestCase("i1234")]
        public void ShouldThrowExceptionIfCommandDoesNotExist(string line)
        {
//            _mockValidator.Setup(v => v.IsValid(It.IsAny<string[]>())).Returns(true);
            var commandArgumentParser = new CommandArgumentParser(_mockValidator.Object);
            var exception = Assert.Throws<ArgumentException>(() => commandArgumentParser.Parse(line));

            Assert.That(exception.Message, Is.EqualTo(string.Format("{0} Does not exist as a command", line.ToUpper().Trim())));
        }

        [TestCase("X")]
        [TestCase("x")]
        [TestCase(" x")]
        [TestCase("x ")]
        public void ShouldShowCommandTypeAsExitWhenGivenX(string line)
        {
            _mockValidator.Setup(v => v.IsValid(It.IsAny<string[]>())).Returns(true);
            var commandArgumentParser = new CommandArgumentParser(_mockValidator.Object);
        
            commandArgumentParser.Parse(line);

            Assert.That(commandArgumentParser.CommandType, Is.EqualTo(CommandType.Exit));
        }

        [Test()]
        public void ShouldRaiseExceptionIfExitValidatorIsNotValid()
        {
            _mockValidator.Setup(v => v.IsValid(It.IsAny<string[]>())).Returns(false);
            var commandArgumentParser = new CommandArgumentParser(_mockValidator.Object);
            var exception = Assert.Throws<ArgumentException>(() => commandArgumentParser.Parse("x 1"));

            Assert.That(exception.Message, Is.EqualTo("Exit command is only expecting 1 argument eg 'X'"));
        }

        [TestCase("I 1 1", CommandType.Create, 1, 1)]
        public void ShouldShowCommandTypeAsCreateWhenGivenIAndGetMAndNValues(string line, CommandType expectedCommandType, int expectedM, int expectedN)
        {
            _mockValidator.Setup(v => v.IsValid(It.IsAny<string[]>())).Returns(true);
            var commandArgumentParser = new CommandArgumentParser(_mockValidator.Object);
            commandArgumentParser.Parse(line);

            Assert.That(commandArgumentParser.CommandType, Is.EqualTo(expectedCommandType));
            Assert.That(commandArgumentParser.M, Is.EqualTo(expectedM));
            Assert.That(commandArgumentParser.N, Is.EqualTo(expectedN));
        }

        [TestCase("I 0 1")]
        public void ShouldRaiseExceptionIfCreateValidatorIsNotValid(string line)
        {
            _mockValidator.Setup(v => v.IsValid(It.IsAny<string[]>())).Returns(false);
            var commandArgumentParser = new CommandArgumentParser(_mockValidator.Object);
            var exception = Assert.Throws<ArgumentException>(() => commandArgumentParser.Parse(line));

            Assert.That(exception.Message, Is.EqualTo("Create command is expecting arguments in following format eg 'I 2 3'"));
        }

        [Test]
        public void ShouldShowCommandTypeAsShowWhenPassedS()
        {
            _mockValidator.Setup(v => v.IsValid(It.IsAny<string[]>())).Returns(true);
            var commandArgumentParser = new CommandArgumentParser(_mockValidator.Object);

            commandArgumentParser.Parse("S");

            Assert.That(commandArgumentParser.CommandType, Is.EqualTo(CommandType.Show));
        }

        [TestCase("S 1")]
        public void ShouldRaiseExceptionIfShowValidatorIsNotValid(string line)
        {
            _mockValidator.Setup(v => v.IsValid(It.IsAny<string[]>())).Returns(false);
            var commandArgumentParser = new CommandArgumentParser(_mockValidator.Object);
            var exception = Assert.Throws<ArgumentException>(() => commandArgumentParser.Parse(line));

            Assert.That(exception.Message, Is.EqualTo("Show command is expecting arguments in following format eg 'S'"));
        }

        [TestCase(1, 2, 'C', "L 1 2 C")]
        [TestCase(5, 6, 'A', "L 5 6 A")]
        public void ShouldSetX_Y_AndColourOnColourPixelWhenPassedLXYColour(int expectedX, int expectedY, char expectedColour, string line)
        {
            _mockValidator.Setup(v => v.IsValid(It.IsAny<string[]>())).Returns(true);
            var commandArgumentParser = new CommandArgumentParser(_mockValidator.Object);

            commandArgumentParser.Parse(line);

            Assert.That(commandArgumentParser.CommandType, Is.EqualTo(CommandType.ColourPixel));
            Assert.That(commandArgumentParser.X, Is.EqualTo(expectedX));
            Assert.That(commandArgumentParser.Y, Is.EqualTo(expectedY));
            Assert.That(commandArgumentParser.Colour, Is.EqualTo(expectedColour));
        }

        [TestCase("L 1 2 C")]
        public void ShouldRaiseExceptionIfColourPixelValidatorIsNotValid(string line)
        {
            _mockValidator.Setup(v => v.IsValid(It.IsAny<string[]>())).Returns(false);
            var commandArgumentParser = new CommandArgumentParser(_mockValidator.Object);
            var exception = Assert.Throws<ArgumentException>(() => commandArgumentParser.Parse(line));

            Assert.That(exception.Message, Is.EqualTo("ColourPixel command is expecting arguments in following format eg 'L 1 2 C'"));
        }

        [Test]
        public void ShouldShowCommandTypeWhenPassedC()
        {
            _mockValidator.Setup(v => v.IsValid(It.IsAny<string[]>())).Returns(true);
            var commandArgumentParser = new CommandArgumentParser(_mockValidator.Object);

            commandArgumentParser.Parse("C");

            Assert.That(commandArgumentParser.CommandType, Is.EqualTo(CommandType.Clear));
        }

        [TestCase("C")]
        [TestCase("C ")]
        [TestCase(" c")]
        public void ShouldRaiseExceptionIfClearValidatorIsNotValid(string line)
        {
            _mockValidator.Setup(v => v.IsValid(It.IsAny<string[]>())).Returns(false);
            var commandArgumentParser = new CommandArgumentParser(_mockValidator.Object);
            var exception = Assert.Throws<ArgumentException>(() => commandArgumentParser.Parse(line));

            Assert.That(exception.Message, Is.EqualTo("Clear command is expecting arguments in following format eg 'C'"));
        }

        [TestCase(1, 2, 4, 'C', "V 1 2 4 C")]
        [TestCase(2, 3, 4, 'W', "V 2 3 4 W")]
        public void ShouldSetX_Y1_Y2_AndColourOnVerticalSegmentWhenPassedVXY1Y2Colour(int expectedX, int expectedY1, int expectedY2, char expectedColour, string line)
        {
            _mockValidator.Setup(v => v.IsValid(It.IsAny<string[]>())).Returns(true);
            var commandArgumentParser = new CommandArgumentParser(_mockValidator.Object);

            commandArgumentParser.Parse(line);

            Assert.That(commandArgumentParser.CommandType, Is.EqualTo(CommandType.VerticalSegment));
            Assert.That(commandArgumentParser.X, Is.EqualTo(expectedX));
            Assert.That(commandArgumentParser.Y1, Is.EqualTo(expectedY1));
            Assert.That(commandArgumentParser.Y2, Is.EqualTo(expectedY2));
            Assert.That(commandArgumentParser.Colour, Is.EqualTo(expectedColour));
        }

        [TestCase("V 1 2 3 A")]
        public void ShouldRaiseExceptionIfVerticalSegmentValidatorIsNotValid(string line)
        {
            _mockValidator.Setup(v => v.IsValid(It.IsAny<string[]>())).Returns(false);
            var commandArgumentParser = new CommandArgumentParser(_mockValidator.Object);
            var exception = Assert.Throws<ArgumentException>(() => commandArgumentParser.Parse(line));

            Assert.That(exception.Message, Is.EqualTo("VerticalSegment command is expecting arguments in following format eg 'V 1 2 3 A'"));
        }





        [TestCase(1, 2, 4, 'C', "H 1 2 4 C")]
        [TestCase(2, 3, 4, 'W', "H 2 3 4 W")]
        public void ShouldSetX1_X2_Y_AndColourOnHorizontalSegmentWhenPassedHX1X2YColour(int expectedX1, int expectedX2, int expectedY, char expectedColour, string line)
        {
            _mockValidator.Setup(v => v.IsValid(It.IsAny<string[]>())).Returns(true);
            var commandArgumentParser = new CommandArgumentParser(_mockValidator.Object);

            commandArgumentParser.Parse(line);

            Assert.That(commandArgumentParser.CommandType, Is.EqualTo(CommandType.HorizontalSegment));
            Assert.That(commandArgumentParser.X1, Is.EqualTo(expectedX1));
            Assert.That(commandArgumentParser.X2, Is.EqualTo(expectedX2));
            Assert.That(commandArgumentParser.Y, Is.EqualTo(expectedY));
            Assert.That(commandArgumentParser.Colour, Is.EqualTo(expectedColour));
        }

        [TestCase("H 1 2 3 A")]
        public void ShouldRaiseExceptionIfHorizontalSegmentValidatorIsNotValid(string line)
        {   
            _mockValidator.Setup(v => v.IsValid(It.IsAny<string[]>())).Returns(false);
            var commandArgumentParser = new CommandArgumentParser(_mockValidator.Object);
            var exception = Assert.Throws<ArgumentException>(() => commandArgumentParser.Parse(line));

            Assert.That(exception.Message, Is.EqualTo("HorizontalSegment command is expecting arguments in following format eg 'H 1 2 3 A'"));
        }
    }
}
