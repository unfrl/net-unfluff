using System.Collections.Generic;
using AngleSharp.Html.Dom;

namespace Unfluff.Extractors
{
    public class LanguageExtractor : BaseExtractor
    {
        public LanguageExtractor()
        : base(
            new Queue<string>(new List<string> { "meta[name=\"lang\"]", "meta[http-equiv=\"content-language\"]" }),
                "content")
        { }

        public override string ExtractContent(IHtmlDocument document)
        {
            string language = document.QuerySelector("html")?.GetAttribute("lang");
            return !string.IsNullOrEmpty(language) ? language : base.ExtractContent(document);
        }
    }
}