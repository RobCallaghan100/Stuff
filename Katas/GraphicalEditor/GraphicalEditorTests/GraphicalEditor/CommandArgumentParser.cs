namespace GraphicalEditor
{
    public class CommandArgumentParser
    {
        private readonly string _line;

        public CommandArgumentParser(string line)
        {
            _line = line;
        }

        public CommandType Command()
        {
            return CommandType.Create;
        }
    }
}