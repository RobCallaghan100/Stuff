namespace Extractor
{
    using System.Collections.Generic;

    public class Extractor
    {
        public int GetPageCount()
        {
            return 10;
        }

        public IEnumerable<string> GetPageLinks()
        {
            return new List<string>
            {
                "a",
                "b",
                "c",
                "d",
                "e"
            };
        }
    }
}