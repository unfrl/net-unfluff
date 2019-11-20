using System.Collections.Generic;

namespace Unfluff.Extractors
{
    public class ImageExtractor : BaseExtractor
    {
        public ImageExtractor()
            : base(new Queue<string>(new List<string> { "meta[property=\"og:image\"]" }), "content")
        {
        }
    }
}