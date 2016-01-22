using static System.Int32;

namespace GraphicalEditor
{
    using System;
    using Interfaces;

    public class CommandArgumentParser : ICommandArgumentParser
    {
        private readonly IValidator _validator;
        private CommandType _commandType;
        private int _m;
        private int _n;

        public CommandArgumentParser(IValidator validator)
        {
            _validator = validator;
            _commandType = CommandType.None;
        }

        public CommandArgumentParser()
        {
        }

        private IValidator GetValidator(CommandType commandType)
        {
            if (_validator == null)
            {
                return ValidatorFactory.GetValidator(commandType);
            }

            return _validator;
        }

        public void Parse(string line)
        {
            var splitLine = line.Trim().ToUpper().Split(' ');
            var command = splitLine[0];

            switch (command)
            {
                case "":
                    _commandType = CommandType.None;
                    break;

                case "X":
                    if (!IsValid(CommandType.Exit, splitLine))
                    {
                        throw new ArgumentException("Exit command is only expecting 1 argument eg 'X'");
                    }

                    _commandType = CommandType.Exit;
                    break;

                case "I":
                    if (!IsValid(CommandType.Create, splitLine))
                    {
                        throw new ArgumentException("Create command is expecting arguments in following format eg 'I 2 3'");
                    }

                    _m = GetValue(splitLine[1]);
                    _n = GetValue(splitLine[2]);

                    _commandType = CommandType.Create;
                    break;

                case "S":
                    if (!IsValid(CommandType.Show, splitLine))
                    {
                        throw new ArgumentException("Show command is expecting arguments in following format eg 'S'");
                    }

                    _commandType = CommandType.Show;
                    break;
                        
                case "L":
                    if (!IsValid(CommandType.ColourPixel, splitLine))
                    {
                        throw new ArgumentException("ColourPixel command is expecting arguments in following format eg 'L 1 2 C'");
                    }

                    _commandType = CommandType.ColourPixel;
                    break;
            }
        }

        private bool IsValid(CommandType commandType, string[] splitLine)
        {
            return GetValidator(commandType).IsValid(splitLine);
        }

        private static int GetValue(string arg)
        {
            int value;
            TryParse(arg, out value);

            return value;
        }

        public CommandType CommandType
        {
            get { return _commandType; }
        }

        public int M { get { return _m;  } }
        public int N { get { return _n;  } }
        public int X { get; }
        public int Y { get; }
        public char Colour { get; }
    }
}