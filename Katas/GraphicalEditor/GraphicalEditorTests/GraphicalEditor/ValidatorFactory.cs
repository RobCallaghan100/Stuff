namespace GraphicalEditor
{
    using System;
    using Interfaces;
    using Validators;

    public static class ValidatorFactory
    {
        public static IValidator GetValidator(CommandType commandType)
        {
            switch (commandType)
            {
                case CommandType.Exit:
                    return new ExitValidator();

                case CommandType.Create:
                    return new CreateValidator();

                case CommandType.Show:
                    return new ShowValidator();

                case CommandType.ColourPixel:
                    return new ColourPixelValidator();

                case CommandType.Clear:
                    return new ClearValidator();

                case CommandType.VerticalSegment:
                    return new VerticalSegmentValidator();

                default:
                    throw new ArgumentException("Should have a command type");
            }
        }
    }
}