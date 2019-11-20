using System;
using System.Collections.Generic;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace Unfluff.Extractors
{
    public abstract class BaseExtractor
    {
        private readonly string _attribute;
        private readonly Queue<string> _selectors;

        protected BaseExtractor(Queue<string> selectors, string attribute)
        {
            if (selectors == null) throw new ArgumentNullException(nameof(selectors));

            if (selectors.Count <= 0) throw new ArgumentException(nameof(selectors));

            if (string.IsNullOrEmpty(attribute)) throw new ArgumentNullException(nameof(attribute));

            _selectors = selectors;
            _attribute = attribute;
        }

        public virtual string ExtractContent(IHtmlDocument document)
        {
            if (document == null) throw new ArgumentNullException(nameof(document));

            while (_selectors.Count > 0)
            {
                string selector = _selectors.Dequeue();
                IElement element = document.QuerySelector(selector);
                if (element != null) return element.GetAttribute(_attribute);
            }

            return "";
        }
    }
}