namespace GraphicalEditor.Interfaces
{
    public interface IImage 
    {
        void Create(int m, int n);
        string Show();
        void Clear();
        void ColourPixel(int x, int y, char colour);
    }
}