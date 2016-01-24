using GraphicalEditor.Interfaces;

namespace GraphicalEditor.Validators
{
    using System;

    public class ColourPixelValidator : IValidator
    {
        public bool IsValid(string[] args)
        {
            if (!IsExactlyFourArguments(args))
            {
                return false;
            }

            if (!IsFirstArgumentAnL(args))
            {
                return false;
            }
            
            if (!IsArgumentAnInt(args[1]))
            {
                return false;
            }

            if (!IsArgumentInRange(args[1]))
            {
                return false;
            }

            if (!IsArgumentAnInt(args[2]))
            {
                return false;
            }

            if (!IsArgumentInRange(args[2]))    
            {
                return false;
            }

            return true;
        }

        private static bool IsArgumentInRange(string arg)
        {
            int value;
            Int32.TryParse(arg, out value);

            return value >= ImageDimension.Low && value <= ImageDimension.High;
        }

        private static bool IsArgumentAnInt(string arg)
        {
            int value;
            if (!int.TryParse(arg, out value))
            {
                return false;
            }

            return true;
        }

        private static bool IsFirstArgumentAnL(string[] args)
        {
            return args[0].ToUpper().Trim() == "L";
        }

        private static bool IsExactlyFourArguments(string[] args)
        {
            return args.Length == 4;
        }
    }
}
