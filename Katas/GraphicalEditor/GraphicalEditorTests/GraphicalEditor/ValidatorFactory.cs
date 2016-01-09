namespace GraphicalEditor
{
    using Interfaces;
    using Validators;

    public class ValidatorFactory : IValidatorFactory
    {
        public IValidator GetValidator(CommandType commandType)
        {
            return new ExitValidator();
        }
    }
}