using GraphicalEditor.Interfaces;

namespace GraphicalEditor.Validators
{
    public class RangeValidator : IRangeValidator
    {
        public bool IsInRange(int startRange, int endRange, int value)
        {
            return true;
        }
    }
}
