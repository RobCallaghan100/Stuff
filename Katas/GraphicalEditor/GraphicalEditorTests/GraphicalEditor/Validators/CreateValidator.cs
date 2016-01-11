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

            if (!IsSecondArgumentAnInt(args[1]))
            {
                return false;
            }

            if (!IsThirdArgumentAnInt(args[2]))
            {
                return false;
            }

            return true;
        }

        private static bool IsFirstArgumentAnI(string[] args)
        {
            return args[0].ToUpper().Trim() == "I";
        }

        private static bool IsSecondArgumentAnInt(string arg)
        {
            int m = 0;
            TryParse(arg, out m);

            if (m == 0)
            {
                return false;
            }

            return true;
        }

        private static bool IsThirdArgumentAnInt(string arg)
        {
            int n = 0;
            TryParse(arg, out n);

            if (n == 0)
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
