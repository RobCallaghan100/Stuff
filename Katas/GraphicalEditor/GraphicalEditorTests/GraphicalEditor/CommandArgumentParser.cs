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
                    // TODO: tidy up
                    int m = 0;
                    int n = 0;
                    Int32.TryParse(splitLine[1], out m);
                    Int32.TryParse(splitLine[2], out n);

                    _m = m;
                    _n = n;
                    _commandType = GraphicalEditor.CommandType.Create;
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