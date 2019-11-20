using System.Collections.Generic;

namespace Unfluff.Extractors
{
    public class AuthorExtractor : BaseExtractor
    {
        public AuthorExtractor()
            : base(new Queue<string>(new List<string> { "meta[name=\"author\"]" }), "content")
        {
        }
    }
}