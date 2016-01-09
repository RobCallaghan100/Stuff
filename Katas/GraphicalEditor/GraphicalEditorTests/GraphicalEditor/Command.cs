﻿namespace GraphicalEditor
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
            // create a command arguments object? eg x.command = "I", x.arguments[] = {1,1}??
            line = line.ToUpper().Trim();
            var splitLine = line.Split(' ');
            if (splitLine.Length == 0)
            {
                throw new ArgumentException("CommandType input has no arguments");
            }

            var command = splitLine[0];

            if (command == "X")
            {
                _image = null;
            }

            if (command == "I")
            {
                int m;
                int n;
                Int32.TryParse(splitLine[1], out m);
                Int32.TryParse(splitLine[2], out n);

                _image.Create(m, n);
            }
        }

        public IImage Image
        {
            get { return _image; }
        }
    }
}