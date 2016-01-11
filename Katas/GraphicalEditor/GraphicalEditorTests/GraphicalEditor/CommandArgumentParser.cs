namespace GraphicalEditor
{
    using System;
    using Interfaces;

    public class CommandArgumentParser : ICommandArgumentParser
    {
        private readonly IValidatorFactory _validatorFactory;
        private CommandType _commandType;
        private int _m;
        private int _n;

        public CommandArgumentParser(IValidatorFactory validatorFactory)
        {
            _validatorFactory = validatorFactory;
            _commandType = CommandType.None;
        }

        public void Parse(string line)
        {
            IValidator validator;

            var splitLine = line.Trim().ToUpper().Split(' ');
            var command = splitLine[0];

            switch (command)
            {
                case "":
                    _commandType = GraphicalEditor.CommandType.None;
                    break;

                case "X":
                    validator = _validatorFactory.GetValidator(CommandType.Exit);

                    if (!validator.IsValid(splitLine))
                    {
                        throw new ArgumentException("Exit command is only expecting 1 argument eg 'X'");
                    }

                    _commandType = GraphicalEditor.CommandType.Exit;
                    break;

                case "I":
                    validator = _validatorFactory.GetValidator(CommandType.Create);

                    if (!validator.IsValid(splitLine))
                    {
                        throw new ArgumentException("Create command is expecting arguments in following format eg 'I 2 3'");
                    }

                    _m = GetValue(splitLine[1]);
                    _n = GetValue(splitLine[2]);

                    _commandType = GraphicalEditor.CommandType.Create;
                    break;
            }
        }

        private static int GetValue(string arg)
        {
            int value = 0;
            Int32.TryParse(arg, out value);

            return value;
        }

        public CommandType CommandType
        {
            get { return _commandType; }
        }

        public int M { get { return _m;  } }
        public int N { get { return _n;  } }
    }
}