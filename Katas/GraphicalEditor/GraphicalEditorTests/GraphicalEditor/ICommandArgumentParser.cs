namespace GraphicalEditor
{
    public interface ICommandArgumentParser
    {
        void Parse(string line);
        CommandType CommandType();
    }
}