using System.Collections.Generic;

using AngleSharp.Html.Dom;

namespace Unfluff.Extractors
{
    public class TitleExtractor : BaseExtractor
    {
        public TitleExtractor()
            : base(
                new Queue<string>(new List<string> { "meta[property=\"og:title\"]", "meta[name=\"twitter:title\"]" }),
                "content")
        {
        }

        public override string ExtractContent(IHtmlDocument document)
        {
            string content = base.ExtractContent(document);
            return !string.IsNullOrEmpty(content) ? content : document.QuerySelector("title")?.TextContent;
        }
    }
}