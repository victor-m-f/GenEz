using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Distrib.Helper.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PostAsJsonAsync<T>(
            this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString, System.Text.Encoding.UTF8, "application/json");
            return await httpClient.PostAsync(url, content);
        }

        public static async Task<HttpResponseMessage> PutAsJsonAsync<T>(
            this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return await httpClient.PutAsync(url, content);
        }

        public static async Task<HttpResponseMessage> GetAsJsonAsync<T>(
            this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(httpClient.BaseAddress, url),
                Content = new StringContent(dataAsString, Encoding.UTF8, "application/json"),
            };
            var result = await httpClient.SendAsync(request).ConfigureAwait(false);
            return result;
        }

        public static async Task<HttpResponseMessage> DeleteAsJsonAsync<T>(
            this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(httpClient.BaseAddress, url),
                Content = new StringContent(dataAsString, Encoding.UTF8),
            };

            return await httpClient.SendAsync(request).ConfigureAwait(false);
        }

        public static async Task<HttpResponseMessage> PatchAsJsonAsync<T>(
            this HttpClient httpClient, string url, T data)
        {
            var dataAsString = JsonSerializer.Serialize(data);
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), url)
            {
                Content = new StringContent(dataAsString, System.Text.Encoding.UTF8, "application/json"),
            };
            return await httpClient.SendAsync(request);
        }

        public static void AddAsStringContent(this MultipartFormDataContent multipartContent, object @object)
        {
            foreach (var prop in @object.GetType().GetProperties())
            {
                var value = prop.GetValue(@object) != null ? prop.GetValue(@object).ToString() : string.Empty;
                multipartContent.Add(new StringContent(value), prop.Name);
            }
        }
    }
}
