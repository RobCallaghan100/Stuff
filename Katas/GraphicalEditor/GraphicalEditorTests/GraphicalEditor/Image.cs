using System;
using System.Text;
using GraphicalEditor.Validators;

namespace GraphicalEditor
{
    using Interfaces;

    public class Image : IImage
    {
        private readonly IRangeValidator _rangeValidator;
        private int _m;
        private int _n;

        private string[,] _image;

        public Image(IRangeValidator rangeValidator)
        {
            _rangeValidator = rangeValidator;
        }
            
        public Image()
        {
            _rangeValidator = new RangeValidator();
        }

        public int M => _m;
        public int N => _n;

        public void Create(int m, int n)
        {
            if (!_rangeValidator.IsInRange(1, 250, m))
            {
                throw new ArgumentOutOfRangeException(nameof(m), "m should be between 1 to 250");
            }

            if (!_rangeValidator.IsInRange(1, 250, n))
            {
                throw new ArgumentOutOfRangeException(nameof(n), "n should be between 1 to 250");
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
            SetsDefaultValue("O");
        }

        public void ColourPixel(int x, int y, char colour)
        {
            IsBetween1AndM(x, "x");
            IsBetween1AndN(y, "y");

            _image[y - 1, x - 1] = colour.ToString();
        }

        public void VerticalSegment(int x, int y1, int y2, char colour)
        {
            IsBetween1AndM(x, "x");
            IsBetween1AndN(y1, "y1");
            IsBetween1AndN(y2, "y2");

            for (int i = y1; i <= y2; i++)
            {
                _image[i-1, x-1] = colour.ToString();
            }   
        }

        public void HorizontalSegment(int x1, int x2, int y, char colour)
        {
            IsBetween1AndM(x1, "x1");
            IsBetween1AndM(x2, "x2");
            IsBetween1AndN(y, "y");

            for (int i = x1; i <= x2; i++)
            {
                _image[y - 1, i-1] = colour.ToString();
            }
        }

        private void IsBetween1AndN(int value, string axis)
        {
            if (!_rangeValidator.IsInRange(1, N, value))
            {
                throw new ArgumentOutOfRangeException(axis, $"{axis} should be between 1 and n");
            }
        }

        private void IsBetween1AndM(int value, string axis)
        {
            if (!_rangeValidator.IsInRange(1, M, value))
            {
                throw new ArgumentOutOfRangeException(axis, $"{axis} should be between 1 and m");
            }
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
            return rowNumber == _n - 1;
        }
    }
}
