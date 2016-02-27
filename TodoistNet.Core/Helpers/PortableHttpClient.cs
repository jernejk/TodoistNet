using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace TodoistNet.Core.Helpers
{
    public class PortableHttpClient : IHttpClient
    {
        public async Task<string> ExecuteRequest(Uri requestUri, string method, Dictionary<string, string> requestMessage)
        {
            string content = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                HttpRequestMessage message = new HttpRequestMessage(new HttpMethod(method), requestUri);
                message.Content = new FormUrlEncodedContent(requestMessage);

                try
                {
                    var tasks = await client.SendAsync(message);
                    content = await tasks.Content.ReadAsStringAsync();
                }
                catch (Exception exception)
                {
                }
            }

            return content;
        }

        private void ThrowIfNotSuccessful(int httpCode)
        {
        }
    }
}
