using System.Threading.Tasks;

namespace Unfluff
{
    public interface IUnfluffer
    {
        /// <summary>
        ///     Unfluff HTML into a <see cref="Payload" />.
        /// </summary>
        /// <param name="html">HTML string to parse.</param>
        /// <returns>Unfurled <see cref="Payload" />.</returns>
        Task<Payload> UnfluffHtmlAsync(string html);

        /// <summary>
        ///     Unfluff a URL into a <see cref="Payload" />.
        /// </summary>
        /// <param name="url">URL to parse.</param>
        /// <returns>Unfurled <see cref="Payload" />.</returns>
        Task<Payload> UnfluffUrlAsync(string url);
    }
}