namespace GraphicalEditor
{
    using Interfaces;
    using Validators;

    public class ValidatorFactory : IValidatorFactory
    {
        public IValidator GetValidator(CommandType commandType)
        {
            switch (commandType)
            {
                case CommandType.Exit:
                    return new ExitValidator();

                case CommandType.Create:
                    return new CreateValidator();

                default:
                    return new ExitValidator();
            }
        }
    }
}