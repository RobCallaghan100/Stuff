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

        // TODO: pass in rubbish that is not in our commands, such as "Q x h" etc - Check in Validator class
    }
}
