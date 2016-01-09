namespace GraphicalEditor
{
    using System;
    using System.Linq;
    using System.Runtime.InteropServices;

    public class CommandArgumentParser : ICommandArgumentParser
    {
        private CommandType _commandType;
        private int _m;
        private int _n;

        public CommandArgumentParser()
        {
            _commandType = CommandType.None;
        }

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
                    if (splitLine.Length != 1)
                    {
                        throw new ArgumentException("Exit command is only expecting 1 argument eg 'X'");
                    }

                    _commandType = GraphicalEditor.CommandType.Exit;
                    break;

                case "I":
                    _commandType = GraphicalEditor.CommandType.Create;

                    int m = 0;
                    int n = 0;
                    Int32.TryParse(splitLine[1], out m);
                    Int32.TryParse(splitLine[2], out n);

                    if (m < 1 || m > 250)
                    {
                        throw new ArgumentException("Create command is expecting M and N arguments to be between 1 and 250 eg 'I 4 5'");
                    }
                    break;
            }
        }

        public CommandType CommandType
        {
            get { return _commandType; }
        }

        public int M { get { return _m;  } }
        public int N { get { return _n;  } }
    }
}