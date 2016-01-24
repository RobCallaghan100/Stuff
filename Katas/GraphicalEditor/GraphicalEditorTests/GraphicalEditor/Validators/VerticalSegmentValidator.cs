using GraphicalEditor.Interfaces;

namespace GraphicalEditor.Validators
{
    using System;

    public class VerticalSegmentValidator : IValidator
    {
        public bool IsValid(string[] args)
        {
            if (!IsExactlyFiveArguments(args))
            {
                return false;
            }

            if (!IsFirstArgumentA_V(args))
            {
                return false;
            }
            
            if (!IsArgumentAnInt(args[1]))
            {
                return false;
            }
//
//            if (!IsArgumentInRange(args[1]))
//            {
//                return false;
//            }
//
//            if (!IsArgumentAnInt(args[2]))
//            {
//                return false;
//            }
//
//            if (!IsArgumentInRange(args[2]))    
//            {
//                return false;
//            }
//
            return true;
        }

        private static bool IsArgumentInRange(string arg)
        {
            int value = 0;
            Int32.TryParse(arg, out value);

            return value >= 1 && value <= 250;
        }

        private static bool IsArgumentAnInt(string arg)
        {
            int value = 0;
            if (!int.TryParse(arg, out value))
            {
                return false;
            }

            return true;
        }

        private static bool IsFirstArgumentA_V(string[] args)
        {
            return args[0].ToUpper().Trim() == "V";
        }

        private static bool IsExactlyFiveArguments(string[] args)
        {
            return args.Length == 5;
        }
    }
}
