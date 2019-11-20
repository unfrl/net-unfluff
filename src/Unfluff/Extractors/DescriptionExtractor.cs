using System.Collections.Generic;

namespace Unfluff.Extractors
{
    public class DescriptionExtractor : BaseExtractor
    {
        public DescriptionExtractor()
            : base(
                new Queue<string>(
                    new List<string>
                    {
                        "meta[property=\"og:description\"]",
                        "meta[name=\"twitter:description\"]",
                        "meta[name=\"description\"]"
                    }),
                "content")
        {
        }
    }
}