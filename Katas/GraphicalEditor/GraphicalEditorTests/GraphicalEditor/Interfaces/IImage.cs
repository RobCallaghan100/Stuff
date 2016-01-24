namespace GraphicalEditor.Interfaces
{
    public interface IImage 
    {
        void Create(int m, int n);
        string Show();
        void Clear();
        void ColourPixel(int x, int y, char colour);
        void VerticalSegment(int x, int y1, int y2, char colour);
        void HorizontalSegment(int x1, int x2, int y, char colour);
    }
}