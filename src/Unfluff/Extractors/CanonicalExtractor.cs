using System.Collections.Generic;

namespace Unfluff.Extractors
{
    public class CanonicalExtractor : BaseExtractor
    {
        public CanonicalExtractor()
            : base(new Queue<string>(new List<string> { "link[rel=\"canonical\"]" }), "href")
        {
        }
    }
}