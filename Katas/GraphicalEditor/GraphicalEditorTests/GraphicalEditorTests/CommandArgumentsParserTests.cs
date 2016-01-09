namespace GraphicalEditorTests
{
    using GraphicalEditor;
    using NUnit.Framework;

    [TestFixture]
    public class CommandArgumentsParserTests    
    {
        [TestCase("X")]
        [TestCase("x")]
        [TestCase(" x")]
        [TestCase("x ")]
        public void ShouldShowCommandAsXWhenGivenX(string line)
        {
            var commandArgumentParser = new CommandArgumentParser(line);

            Assert.That(commandArgumentParser.Command, Is.EqualTo(CommandType.Create));
        }
    }
}
