namespace GraphicalEditor
{
    public interface ICommandArgumentParser
    {
        void Parse(string line);
        CommandType CommandType { get; }
        int M { get; }
        int N { get; }
    }
}