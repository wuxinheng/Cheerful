using System.Net;
using System.Net.Http.Headers;

namespace Cheerful
{
    public static class RequstApi
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="httpRequestMessage"></param>
        /// <returns></returns>
        public static async Task<HttpContent> PostAsync(HttpRequestMessage httpRequestMessage)
        {
            HttpContent? httpContent;
            var client = new HttpClient();
            using (var response = await client.SendAsync(httpRequestMessage))
            {
                response.EnsureSuccessStatusCode();
                httpContent = response.Content;
            }
            return httpContent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<byte[]> DownloadToByte(string url)
        {
            HttpClient client = new HttpClient();
            var s = await client.GetByteArrayAsync(url);

            WebClient webClient = new WebClient();
            var s1 = webClient.DownloadData(url);
            return s1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Stream DownloadToStream(string url)
        {
            WebClient webClient = new WebClient();
            var bytes = webClient.DownloadData(url);
            return new MemoryStream(bytes);
        }

    }
}