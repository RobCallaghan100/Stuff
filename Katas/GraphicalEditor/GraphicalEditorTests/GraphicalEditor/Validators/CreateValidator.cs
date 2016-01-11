using GraphicalEditor.Interfaces;
using static System.Int32;

namespace GraphicalEditor.Validators
{
    public class CreateValidator : IValidator
    {
        public bool IsValid(string[] args)
        {
            if (IsThreeArguments(args))
            {
                return false;
            }

            if (!IsSecondParameterAnInt(args[1]))
            {
                return false;
            }

            if (!IsThirdParameterAnInt(args[2]))
            {
                return false;
            }

            return true;
        }

        private static bool IsSecondParameterAnInt(string arg)
        {
            int m = 0;
            TryParse(arg, out m);

            if (m == 0)
            {
                return false;
            }

            return true;
        }

        private static bool IsThirdParameterAnInt(string arg)
        {
            int n = 0;
            TryParse(arg, out n);

            if (n == 0)
            {
                return false;
            }

            return true;
        }

        private static bool IsThreeArguments(string[] args)
        {
            return args.Length != 3;
        }
    }
}
