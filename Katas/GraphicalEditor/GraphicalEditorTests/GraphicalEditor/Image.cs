using System;

namespace GraphicalEditor
{
    public class Image : IImage
    {
        private int _m;
        private int _n;

        public int M { get { return _m; } }
        public int N { get { return _n; } }

        public void Create(int m, int n)
        {
            _m = m;
            _n = n;
        }
    }
}
