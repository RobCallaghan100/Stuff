using GraphicalEditor.Interfaces;
using static System.Int32;

namespace GraphicalEditor.Validators
{
    public class CreateValidator : IValidator
    {
        public bool IsValid(string[] args)
        {
            if (IsExactlyThreeArguments(args))
            {
                return false;
            }

            if (!IsFirstArgumentAnI(args))
            {
                return false;
            }

            if (!IsArgumentAnInt(args[1]))
            {
                return false;
            }

            if (!IsArgumentAnInt(args[2]))
            {
                return false;
            }

            if (!IsArgumentInRange(args[1]))
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
            int m;
            TryParse(arg, out m);
            if (m < 1 || m > 250)
            {
                return false;
            }

            return true;
        }

        private static bool IsFirstArgumentAnI(string[] args)
        {
            return args[0].ToUpper().Trim() == "I";
        }

        private static bool IsArgumentAnInt(string arg)
        {
            int value;
            TryParse(arg, out value);

            if (value == 0)
            {
                return false;
            }

            return true;
        }

        private static bool IsExactlyThreeArguments(string[] args)
        {
            return args.Length != 3;
        }
    }
}
