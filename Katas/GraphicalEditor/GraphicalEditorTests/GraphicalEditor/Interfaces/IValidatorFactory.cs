namespace GraphicalEditor.Interfaces
{
    public interface IValidatorFactory
    {
        IValidator GetValidator(CommandType commandType);
    }
}