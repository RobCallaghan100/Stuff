using GraphicalEditor.Interfaces;

namespace GraphicalEditor.Validators
{
    public class ShowValidator : IValidator
    {
        public bool IsValid(string[] args)
        {
            if (!IsOnlyOneArgument(args))
            {
                return false;
            }

            if (!IsS(args))
            {
                return false;
            }

            return true;
        }

        private static bool IsS(string[] args)
        {
            return args[0].Trim().ToUpper() == "S";
        }

        private static bool IsOnlyOneArgument(string[] args)
        {
            return args.Length == 1;
        }
    }
}
