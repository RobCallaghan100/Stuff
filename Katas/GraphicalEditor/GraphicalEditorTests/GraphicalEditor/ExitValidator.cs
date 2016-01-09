namespace GraphicalEditor
{
    public class ExitValidator : IValidator
    {
        public bool IsValid(string[] arguments)
        {
            if (arguments.Length == 1)
            {
                if (arguments[0].ToUpper().Trim() == "X")
                {
                    return true;
                }

                return false;
            }

            return true;
        }
    }
}