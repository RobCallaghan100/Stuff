namespace GraphicalEditor
{
    using Interfaces;
    using Validators;

    public static class ValidatorFactory
    {
        public static IValidator GetValidator(CommandType commandType)
        {
            switch (commandType)
            {
                case CommandType.Exit:
                    return new ExitValidator();

                case CommandType.Create:
                    return new CreateValidator();

                    case CommandType.Show:
                        return new ShowValidator();

                default:
                    return new ExitValidator();
            }
        }
    }
}