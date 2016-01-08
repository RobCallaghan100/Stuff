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
            if (m < 1)
            {
                throw new ArgumentOutOfRangeException("m", "m should be between 1 to 250");
            }

            if (n < 1)
            {
                throw new ArgumentOutOfRangeException("n", "n should be between 1 to 250");
            }

            _m = m;
            _n = n;
        }
    }
}
