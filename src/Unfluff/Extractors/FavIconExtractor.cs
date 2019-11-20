using System.Collections.Generic;

namespace Unfluff.Extractors
{
    public class FavIconExtractor : BaseExtractor
    {
        public FavIconExtractor()
            : base(new Queue<string>(new List<string> { "link[rel=\"shortcut icon\"]" }), "href")
        {
        }
    }
}