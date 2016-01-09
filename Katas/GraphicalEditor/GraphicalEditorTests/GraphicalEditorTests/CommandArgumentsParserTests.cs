namespace GraphicalEditorTests
{
    using GraphicalEditor;
    using NUnit.Framework;

    [TestFixture]
    public class CommandArgumentsParserTests    
    {
        [TestCase("X")]
        public void ShouldShowCommandAsXWhenGivenX(string line)
        {
            var commandArgumentParser = new CommandArgumentParser(line);

            Assert.That(commandArgumentParser.Command, Is.EqualTo(CommandType.Create));
        }
    }
}
