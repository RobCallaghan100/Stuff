namespace GraphicalEditorTests
{
    using GraphicalEditor;
    using NUnit.Framework;

    [TestFixture]
    public class CommandArgumentsParserTests    
    {
        private CommandArgumentParser _commandArgumentParser;

        [SetUp]
        public void Setup()
        {
            _commandArgumentParser = new CommandArgumentParser();
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
            Assert.That(_commandArgumentParser.CommandType, Is.EqualTo(CommandType.Exit));
        }

        [Test]
        public void ShouldShowCommandTypeAsCreateWhenGivenIAndGetMAndNValues()
        {
            _commandArgumentParser.Parse("I 1 1");

            Assert.That(_commandArgumentParser.CommandType, Is.EqualTo(CommandType.Create));    
            Assert.That(_commandArgumentParser.M, Is.EqualTo(1));
            Assert.That(_commandArgumentParser.N, Is.EqualTo(1));
        }
    }
}
