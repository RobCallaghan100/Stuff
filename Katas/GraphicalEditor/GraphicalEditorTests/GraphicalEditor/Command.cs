namespace GraphicalEditor
{
    public class Command
    {
        private IImage _image;

        public Command(IImage image)
        {
            _image = image;
        }

        public void Input(string line)
        {
            if (line == "X")
            {
                _image = null;
            }

            if (line == "I 1 1")
            {
                _image.Create(1, 1);
            }
        }

        public IImage Image
        {
            get { return _image; }
        }
    }
}