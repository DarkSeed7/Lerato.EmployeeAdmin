using System.Threading.Tasks;
using Http = System.Net.Http;
using Lerato.ApplicationCore.Services.Api;
using Lerato.CompositionRoot.Extensions;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net;
using Lerato.ApplicationServices.Exceptions;

namespace Lerato.ApplicationServices.Services
{
    public class HttpClient : IHttpClient
    {
        private Http.HttpClient httpClient;

        public HttpClient(string authToken = null)
        {
            CreateHttpClient(authToken);
        }

        // read
        public async Task<string> GetAsync(string uri)
        {
            var response = await httpClient.GetAsync(uri);

            return await HandleResponse(response);
        }


        // create
        public async Task<string> PostAsync<T>(string uri, T data)
        {
            var content = CreateStringContent(data);
            var response = await httpClient.PostAsync(uri, content);

            return await HandleResponse(response);
        }

        // update / replace
        public async Task<string> PutAsync<T>(string uri, T data)
        {
            var content = CreateStringContent(data);
            var response = await httpClient.PostAsync(uri, content);

            return await HandleResponse(response);
        }

        // delete
        public async Task<string> DeleteAsync(string uri)
        {
            var response = await httpClient.DeleteAsync(uri);

            return await HandleResponse(response);
        }

        private void CreateHttpClient(string authToken = null)
        {
            if (httpClient.IsNotNull())
            {
                return;
            }

            httpClient = new Http.HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            if (authToken.IsNullOrEmpty())
            {
                httpClient.DefaultRequestHeaders.Authorization = new Http.Headers.AuthenticationHeaderValue("Bearer", authToken);
            }
        }


        private StringContent CreateStringContent<T>(T data)
        {
            var content = new StringContent(JsonConvert.SerializeObject(data));
            content.Headers.ContentType = new Http.Headers.MediaTypeHeaderValue("application/json");

            return content;
        }

        private async Task<string> HandleResponse(HttpResponseMessage response)
        {
            var contentResult = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return contentResult;
            }

            if (response.StatusCode == HttpStatusCode.Forbidden || response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new ServiceAuthenticationException(contentResult);
            }

            throw new HttpRequestExceptionEx(response.StatusCode, contentResult);
        }
    }
}
