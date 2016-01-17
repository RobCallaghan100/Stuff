namespace GraphicalEditorTests
{
    using System;
    using GraphicalEditor;
    using GraphicalEditor.Interfaces;
    using GraphicalEditor.Validators;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class CommandArgumentsParserTests    
    {
        private CommandArgumentParser _commandArgumentParser;
        private Mock<IValidatorFactory> _mockValidatorFactory;

        [SetUp]
        public void Setup()
        {
            _mockValidatorFactory = new Mock<IValidatorFactory>();
            _commandArgumentParser = new CommandArgumentParser(_mockValidatorFactory.Object);
        }

        [TearDown]
        public void Teardown()
        {
            _commandArgumentParser = null;
        }

        [TestCase("")]
        [TestCase(" ")]
        public void ShouldShowCommandTypeAsNoneIfGivenEmptyString(string line)
        {
            _commandArgumentParser.Parse(line);

            Assert.That(_commandArgumentParser.CommandType, Is.EqualTo(CommandType.None));
        }

        [TestCase("X")]
        [TestCase("x")]
        [TestCase(" x")]
        [TestCase("x ")]
        public void ShouldShowCommandTypeAsExitWhenGivenX(string line)
        {
            _mockValidatorFactory.Setup(vf => vf.GetValidator(It.IsAny<CommandType>())).Returns(new ExitValidator());
            _commandArgumentParser.Parse(line);

            Assert.That(_commandArgumentParser.CommandType, Is.EqualTo(CommandType.Exit));
        }

        [TestCase("x 1")]
        [TestCase("x d")]
        [TestCase("x 11 12")]
        public void ShouldRaiseExceptionIfNotOnlyGivenX(string line)
        {
            _mockValidatorFactory.Setup(vf => vf.GetValidator(It.IsAny<CommandType>())).Returns(new ExitValidator());
            var exception = Assert.Throws<ArgumentException>(() => _commandArgumentParser.Parse(line));

            Assert.That(exception.Message, Is.EqualTo("Exit command is only expecting 1 argument eg 'X'"));
        }

        [TestCase("I 1 1", CommandType.Create, 1, 1)]
        [TestCase("i 250 250", CommandType.Create, 250, 250)]
        public void ShouldShowCommandTypeAsCreateWhenGivenIAndGetMAndNValues(string line, CommandType expectedCommandType, int expectedM, int expectedN)
        {
            _mockValidatorFactory.Setup(vf => vf.GetValidator(It.IsAny<CommandType>())).Returns(new CreateValidator());
            _commandArgumentParser.Parse(line);

            Assert.That(_commandArgumentParser.CommandType, Is.EqualTo(expectedCommandType));
            Assert.That(_commandArgumentParser.M, Is.EqualTo(expectedM));
            Assert.That(_commandArgumentParser.N, Is.EqualTo(expectedN));
        }

        [TestCase("I 0 1")]
        [TestCase("I 251 1")]
        [TestCase("i 1 0")]
        [TestCase("I 1 251")]
        public void ShouldRaiseExceptionWhenTryingToCreateImageWhenIMNOutOfBounds(string line)
        {
            _mockValidatorFactory.Setup(vf => vf.GetValidator(It.IsAny<CommandType>())).Returns(new CreateValidator());
            var exception = Assert.Throws<ArgumentException>(() => _commandArgumentParser.Parse(line));

            Assert.That(exception.Message, Is.EqualTo("Create command is expecting arguments in following format eg 'I 2 3'"));
        }


        // TODO: pass in rubbish that is not in our commands, such as "Q x h" etc - Check in Validator class
    }
}
