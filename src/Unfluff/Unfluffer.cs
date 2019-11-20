using System;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using AngleSharp.Html.Dom;
using Unfluff.Extractors;
using Unfluff.Extensions;

namespace Unfluff
{
    public class Unfluffer : IUnfluffer
    {
        private readonly HtmlParser _htmlParser;

        #region Extractors

        private readonly TitleExtractor _titleExtractor;
        private readonly DescriptionExtractor _descriptionExtractor;
        private readonly FavIconExtractor _favIconExtractor;
        private readonly ImageExtractor _imageExtractor;
        private readonly AuthorExtractor _authorExtractor;
        private readonly CanonicalExtractor _canonicalExtractor;

        #endregion

        #region Constructor

        public Unfluffer()
        {
            _htmlParser = new HtmlParser();
            _titleExtractor = new TitleExtractor();
            _descriptionExtractor = new DescriptionExtractor();
            _favIconExtractor = new FavIconExtractor();
            _imageExtractor = new ImageExtractor();
            _authorExtractor = new AuthorExtractor();
            _canonicalExtractor = new CanonicalExtractor();
        }

        #endregion

        #region IUnfluffer

        public async Task<Payload> UnfluffHtmlAsync(string html)
        {
            if (string.IsNullOrEmpty(html))
            {
                throw new ArgumentNullException(nameof(html));
            }

            using (IHtmlDocument document = await _htmlParser.ParseDocumentAsync(html).ConfigureAwait(false))
            {
                return new Payload
                {
                    Title = _titleExtractor.ExtractContent(document),
                    Description = _descriptionExtractor.ExtractContent(document),
                    Image = _imageExtractor.ExtractContent(document),
                    FavIcon = _favIconExtractor.ExtractContent(document),
                    Author = _authorExtractor.ExtractContent(document),
                    Url = _canonicalExtractor.ExtractContent(document)
                };
            }
        }

        public async Task<Payload> UnfluffUrlAsync(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException(nameof(url));
            }

            url = url.NormalizeUrl();

            if (!url.IsValidUrl())
            {
                throw new ArgumentException(url, nameof(url));
            }

            using (HttpClient client = new HttpClient())
            {
                string html = await client.GetStringAsync(url).ConfigureAwait(false);

                return await UnfluffHtmlAsync(html);
            }
        }

        #endregion    
    }
}