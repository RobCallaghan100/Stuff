namespace GraphicalEditorTests
{
    internal class Command
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
        }

        public IImage Image
        {
            get { return _image; }
        }
    }
}