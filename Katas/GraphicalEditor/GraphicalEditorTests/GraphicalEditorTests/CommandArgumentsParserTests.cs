using System;
using GraphicalEditor.Validators;

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
        public void ShouldRaiseExceptionIfNotOnlyGivenX()
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
        [TestCase("I 251 1")]
        [TestCase("i 1 0")]
        [TestCase("I 1 251")]
        public void ShouldRaiseExceptionWhenTryingToCreateImageWhenIMNOutOfBounds(string line)
        {
            _mockValidator.Setup(v => v.IsValid(It.IsAny<string[]>())).Returns(false);
            var commandArgumentParser = new CommandArgumentParser(_mockValidator.Object);
            var exception = Assert.Throws<ArgumentException>(() => commandArgumentParser.Parse(line));

            Assert.That(exception.Message, Is.EqualTo("Create command is expecting arguments in following format eg 'I 2 3'"));
        }

        [Test]
        public void ShouldShowCommandTypeAsShowWhenPassedS()
        {
            var commandArgumentParser = new CommandArgumentParser(_mockValidator.Object);

            commandArgumentParser.Parse("S");

            Assert.That(commandArgumentParser.CommandType, Is.EqualTo(CommandType.Show));
        }

        // TODO: pass in rubbish that is not in our commands, such as "Q x h" etc - Check in Validator class
    }
}
