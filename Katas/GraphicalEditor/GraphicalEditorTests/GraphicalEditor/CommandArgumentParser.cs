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
        private int _x;
        private int _y; 
        private int _y1;
        private int _y2;
        private char _colour;

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

                    SetX(splitLine[1]);
                    SetY(splitLine[2]);
                    SetColour(splitLine[3]);

                    _commandType = CommandType.ColourPixel;
                    break;

                case "C":
                    if (!IsValid(CommandType.Clear, splitLine))
                    {
                        throw new ArgumentException("Clear command is expecting arguments in following format eg 'C'");
                    }

                    _commandType = CommandType.Clear;
                    break;

                default:
                    throw new ArgumentException(string.Format("{0} Does not exist as a command", command));
            }
        }

        private void SetX(string value)
        {
            int x = 0;
            TryParse(value, out x);

            _x = x;
        }
        private void SetY(string value)
        {
            int y = 0;
            TryParse(value, out y);

            _y = y;
        }

        private void SetColour(string colour)
        {
            _colour = char.Parse(colour);
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
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public char Colour { get { return _colour; } }
        public int Y1 { get { return _y1; } }
        public int Y2 { get { return _y2; } }
    }
}