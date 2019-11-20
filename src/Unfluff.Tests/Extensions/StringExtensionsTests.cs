using System.Collections.Generic;
using System.Linq;

using Unfluff.Extensions;

using Xunit;

namespace Unfluff.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [Fact]
        public void IsValidUrl_ReturnsFalse_WhenUrlInvalid()
        {
            const string invalidUrl = "invalid url";

            bool result = invalidUrl.IsValidUrl();
            Assert.False(result);
        }

        [Fact]
        public void IsValidUrl_ReturnsTrue_WhenUrlValid()
        {
            string[] validUrls =
            {
                "https://google.com", "http://google.com", "https://www.google.com", "http://www.google.com"
            };

            IEnumerable<bool> results = validUrls.Select(url => url.IsValidUrl());
            Assert.DoesNotContain(false, results);
        }

        [Fact]
        public void NormalizeUrl_ReturnsNormalizedUrl_WhenUrlMissingHttp()
        {
            const string urlMissingHttp = "stackoverflow.com";
            const string urlCorrected = "http://stackoverflow.com";

            string result = urlMissingHttp.NormalizeUrl();
            Assert.Equal(urlCorrected, result);
        }

        [Fact]
        public void NormalizeUrl_ReturnsSameUrl_WhenUrlValid()
        {
            const string validUrl = "https://stackoverflow.com";

            string result = validUrl.NormalizeUrl();
            Assert.Equal(validUrl, result);
        }
    }
}