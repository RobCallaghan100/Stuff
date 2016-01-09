namespace GraphicalEditor
{
    using Interfaces;

    public class ExitValidator : IValidator
    {
        public bool IsValid(string[] arguments)
        {
            if (IsOnlyOneArgument(arguments))
            {
                if (IsX(arguments))
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        private static bool IsX(string[] arguments)
        {
            return arguments[0].ToUpper().Trim() == "X";
        }

        private static bool IsOnlyOneArgument(string[] arguments)
        {
            return arguments.Length == 1;
        }
    }
}