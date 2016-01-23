namespace GraphicalEditor.Validators
{
    using Interfaces;
    public class ClearValidator : IValidator
    {
        public bool IsValid(string[] args)
        {
            if (args.Length != 1)
            {
                return false;
            }

            return true;
        }
    }
}
