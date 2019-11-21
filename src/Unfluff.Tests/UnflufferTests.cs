using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Unfluff.Test
{
    public class UnflufferTests
    {
        [Fact]
        public async Task UnfluffHtml_ReturnsPayload_WhenSuccessful()
        {
            string html = await new HttpClient().GetStringAsync("https://stackoverflow.com");
            Unfluffer unfluffer = new Unfluffer();

            Payload result = await unfluffer.UnfluffHtmlAsync(html);

            Assert.NotNull(result);
            Assert.NotEmpty(result.Title);
        }

        [Fact]
        public async Task UnfluffHtml_ThrowsArgumentNullException_WhenHtmlIsNull()
        {
            Unfluffer unfluffer = new Unfluffer();

            await Assert.ThrowsAsync<ArgumentNullException>(() => unfluffer.UnfluffHtmlAsync(null));
        }

        [Fact]
        public async Task UnfluffUrl_ReturnsPayload_WhenSuccessful()
        {
            const string validUrl = "https://slack.com/pricing";
            Unfluffer unfluffer = new Unfluffer();

            Payload result = await unfluffer.UnfluffUrlAsync(validUrl);

            Assert.NotNull(result);
            Assert.NotEmpty(result.Title);
            Assert.NotEmpty(result.Language);
        }

        [Fact]
        public async Task UnfluffUrl_ReturnsPayload_WhenUrlRequiresNormalization()
        {
            const string urlMissingHttp = "stackoverflow.com";
            Unfluffer unfluffer = new Unfluffer();

            Payload result = await unfluffer.UnfluffUrlAsync(urlMissingHttp);

            Assert.NotNull(result);
            Assert.NotEmpty(result.Title);
        }

        [Fact]
        public async Task UnfluffUrl_ThrowsArgumentException_WhenUrlInvalid()
        {
            const string invalidUrl = "invalid";
            Unfluffer unfluffer = new Unfluffer();

            await Assert.ThrowsAsync<ArgumentException>(() => unfluffer.UnfluffUrlAsync(invalidUrl));
        }

        [Fact]
        public async Task UnfluffUrl_ThrowsArgumentNullException_WhenUrlIsNull()
        {
            Unfluffer unfluffer = new Unfluffer();

            await Assert.ThrowsAsync<ArgumentNullException>(() => unfluffer.UnfluffUrlAsync(null));
        }
    }
}
