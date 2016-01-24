namespace GraphicalEditor.Interfaces
{
    public interface ICommandArgumentParser
    {
        void Parse(string line);
        CommandType CommandType { get; }
        int M { get; }
        int N { get; }
        int X { get; }
        int Y { get; }
        char Colour { get; }
        int Y1 { get; }
        int Y2 { get; }
        int X1 { get; }
        int X2 { get; }
    }
}