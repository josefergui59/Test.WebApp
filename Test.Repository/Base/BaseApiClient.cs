using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Test.Core.Common;
using Test.Repository.Helpers.Extensions;

namespace Test.Repository.Base
{
    public class BaseApiClient
    {
        public async Task<HttpResponseMessage> SendAsyncBase(HttpClient client, HttpRequestMessage request)
        {
            var response = await client.SendAsync(request);
            response.HandleResponse();

            return response;
        }

        protected HttpRequestMessage CreateHttpRequestMesssage(HttpMethod httpMethod, string requestUri)
        {
            var httpRequestMessage = new HttpRequestMessage(httpMethod, requestUri);
            return httpRequestMessage;
        }

        //add header database
        protected HttpRequestMessage CreateHttpRequestMesssage(HttpMethod httpMethod, string requestUri, string dataBase)
        {
            var httpRequestMessage = new HttpRequestMessage(httpMethod, requestUri);
            httpRequestMessage.Headers.Add(CustomHeaders.DatabaseNameHeader, dataBase);

            return httpRequestMessage;
        }

        protected void AddJsonContent<T>(HttpRequestMessage request, T content)
        {
            request.Content = new StringContent(
                                    JsonSerializer.Serialize(content, GetJsonSerializerOptions()),
                                    Encoding.UTF8,
                                    "application/json"
                                  );
        }

        protected async Task<T> GetContentResultAsyn<T>(HttpResponseMessage response)
        {
            using Stream responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(responseStream, GetJsonSerializerOptions());
        }

        protected JsonSerializerOptions GetJsonSerializerOptions()
        {
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return jsonSerializerOptions;
        }
    }
}
