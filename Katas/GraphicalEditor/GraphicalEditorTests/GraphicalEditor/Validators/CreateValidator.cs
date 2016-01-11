using System;
using GraphicalEditor.Interfaces;

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

            int m = 0;
            Int32.TryParse(args[1], out m);

            if (m == 0)
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
