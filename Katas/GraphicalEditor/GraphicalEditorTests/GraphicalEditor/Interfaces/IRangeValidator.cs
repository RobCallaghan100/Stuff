namespace GraphicalEditor.Interfaces
{
    public interface IRangeValidator
    {
        bool IsInRange(int startRange, int endRange, int value);
    }
}
