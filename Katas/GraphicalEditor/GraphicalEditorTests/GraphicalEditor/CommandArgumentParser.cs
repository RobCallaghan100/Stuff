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
        private int _x1;
        private int _x2;
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

                    SetColourPixelArgumentValues(splitLine);

                    _commandType = CommandType.ColourPixel;
                    break;

                case "C":
                    if (!IsValid(CommandType.Clear, splitLine))
                    {
                        throw new ArgumentException("Clear command is expecting arguments in following format eg 'C'");
                    }

                    _commandType = CommandType.Clear;
                    break;

                case "V":
                    if (!IsValid(CommandType.VerticalSegment, splitLine))
                    {
                        throw new ArgumentException("VerticalSegment command is expecting arguments in following format eg 'V 1 2 3 A'");
                    }

                    SetVerticalSegmentArgumentValues(splitLine);
                    _commandType = CommandType.VerticalSegment;
                    break;

                case "H":
                    SetHorizontalSegmentArgumentValues(splitLine);
                    _commandType = CommandType.HorizontalSegment;
                    break;

                default:
                    throw new ArgumentException(string.Format("{0} Does not exist as a command", command));
            }
        }

        private void SetColourPixelArgumentValues(string[] splitLine)
        {
            _x = GetNumber(splitLine[1]);
            _y = GetNumber(splitLine[2]);
            _colour = GetColour(splitLine[3]);
        }

        private void SetVerticalSegmentArgumentValues(string[] splitLine)
        {
            _x = GetNumber(splitLine[1]);
            _y1 = GetNumber(splitLine[2]);
            _y2 = GetNumber(splitLine[3]);
            _colour = GetColour(splitLine[4]);
        }

        private void SetHorizontalSegmentArgumentValues(string[] splitLine)
        {
            _x1 = GetNumber(splitLine[1]);
            _x2 = GetNumber(splitLine[2]);
            _y = GetNumber(splitLine[3]);
            _colour = GetColour(splitLine[4]);
        }

        private int GetNumber(string value)
        {
            int num = 0;
            TryParse(value, out num);

            return num;
        }

        private char GetColour(string colour)
        {
            return char.Parse(colour);
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

        public int M { get { return _m; } }
        public int N { get { return _n; } }
        public int X { get { return _x; } }
        public int Y { get { return _y; } }
        public char Colour { get { return _colour; } }
        public int Y1 { get { return _y1; } }
        public int Y2 { get { return _y2; } }
        public int X1 { get { return _x1; } }
        public int X2 { get { return _x2; } }
    }
}