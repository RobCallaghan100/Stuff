namespace GraphicalEditor
{
    using System;
    using Interfaces;

    public class Command
    {
        private IImage _image;
        private ICommandArgumentParser _commandArgumentParser;

        public Command(IImage image, ICommandArgumentParser commandArgumentParser)
        {
            _image = image;
            _commandArgumentParser = commandArgumentParser;
        }

        public Command()
        {
            _image = new Image();

            _commandArgumentParser = new CommandArgumentParser();
        }

        public void Input(string line)
        {
            _commandArgumentParser.Parse(line);

            switch (_commandArgumentParser.CommandType)
            {
                case CommandType.Exit:
                    _image = null;
                    break;

                case CommandType.Create:
                    _image.Create(_commandArgumentParser.M, _commandArgumentParser.N);
                    break;

                case CommandType.Show:
                    Console.WriteLine(_image.Show()); // TODO: Should Console object be injected in???
                    break;

                case CommandType.Clear:
                    _image.Clear();
                    break;

                case CommandType.ColourPixel:
                    _image.ColourPixel(_commandArgumentParser.X, _commandArgumentParser.Y, _commandArgumentParser.Colour);
                    break;

                case CommandType.VerticalSegment:
                    _image.VerticalSegment(_commandArgumentParser.X, _commandArgumentParser.Y1, _commandArgumentParser.Y2, _commandArgumentParser.Colour);
                    break;

                case CommandType.HorizontalSegment:
                    _image.HorizontalSegment(_commandArgumentParser.X1, _commandArgumentParser.X2, _commandArgumentParser.Y, _commandArgumentParser.Colour);
                    break;

                default:
                    throw new ArgumentException("CommandType input has no arguments");
            }
        }

        public IImage Image
        {
            get { return _image; }
        }
    }
}