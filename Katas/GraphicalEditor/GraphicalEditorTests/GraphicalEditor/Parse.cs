namespace GraphicalEditor
{
    using System.Linq;

    public class CommandArgumentParser : ICommandArgumentParser
    {
        private CommandType _commandType;

        public void Parse(string line)
        {
            var splitLine = line.Trim().ToUpper().Split(' ');

            var command = splitLine[0];

            switch (command)
            {
                case "":
                    _commandType = GraphicalEditor.CommandType.None;
                    break;

                case "X":
                    _commandType = GraphicalEditor.CommandType.Exit;
                    break;
            }
        }

        public CommandType CommandType()
        {
            return _commandType;
        }
    }
}