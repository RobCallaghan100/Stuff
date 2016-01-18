using System;
using System.Linq;
using System.Text;

namespace GraphicalEditor
{
    using Interfaces;

    public class Image : IImage
    {
        private int _m;
        private int _n;

        private string[,] _image;

        public int M { get { return _m; } }
        public int N { get { return _n; } }

        public void Create(int m, int n)
        {
            if (m < 1 || m > 250)
            {
                throw new ArgumentOutOfRangeException("m", "m should be between 1 to 250");
            }

            if (n < 1 || n > 250)
            {
                throw new ArgumentOutOfRangeException("n", "n should be between 1 to 250");
            }

            _m = m;
            _n = n;

            _image = new string[n, m];

            SetsDefaultValue("O");
        }

        public string Show()
        {
            return ToString();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void ColourPixel(int x, int y, char colour)
        {
            throw new NotImplementedException();
        }

        private void SetsDefaultValue(string value)
        {
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _m; j++)
                {
                    _image[i, j] = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _n; i++)
            {
                for (int j = 0; j < _m; j++)
                {
                    sb.Append(_image[i, j]);
                }

                if (!IsLastRow(i))
                {
                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }

        private bool IsLastRow(int rowNumber)
        {
            return rowNumber == (_n - 1);
        }


    }
}
