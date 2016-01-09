namespace GraphicalEditorTests
{
    using GraphicalEditor;
    using NUnit.Framework;

    [TestFixture]
    public class CommandArgumentsParserTests    
    {
        [Test]
        public void ShouldShowCommandTypeAsNoneIfGivenEmptyString()
        {
            var commandArgumentParser = new CommandArgumentParser("");

            Assert.That(commandArgumentParser.CommandType, Is.EqualTo(CommandType.None));
        }

        [TestCase("X")]
        [TestCase("x")]
        [TestCase(" x")]
        [TestCase("x ")]
        public void ShouldShowCommandTypeAsExitWhenGivenX(string line)
        {
            var commandArgumentParser = new CommandArgumentParser(line);

            Assert.That(commandArgumentParser.CommandType, Is.EqualTo(CommandType.Exit));
        }
    }
}
