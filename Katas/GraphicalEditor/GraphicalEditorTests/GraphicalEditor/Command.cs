namespace GraphicalEditor
{
    using System;

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

            if (_commandArgumentParser.CommandType == CommandType.None)
            {
                throw new ArgumentException("CommandType input has no arguments");
            }

            if (_commandArgumentParser.CommandType == CommandType.Exit)
            {
                _image = null;
            }

            if (_commandArgumentParser.CommandType == CommandType.Create)
            {
                _image.Create(_commandArgumentParser.M, _commandArgumentParser.N);
            }
        }

        public IImage Image
        {
            get { return _image; }
        }
    }
}