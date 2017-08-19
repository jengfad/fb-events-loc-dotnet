using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace FEL.Core
{
    public interface IFbClient
    {
        Task<T> GetAsync<T>(string endpoint, string args = null);
    }

    public class FbClient : IFbClient
    {
        private readonly HttpClient _httpClient;
        private string _accessToken;

        public FbClient(string accessToken)
        {

            _accessToken = accessToken;

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://graph.facebook.com/v2.10/")
            };

            _httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> GetAsync<T>(string endpoint, string args = null)
        {
            string createText = $"{endpoint}?access_token={_accessToken}&{args}";
            File.WriteAllText("generatedUrl.txt", createText);

            var response = await _httpClient.GetAsync($"{endpoint}?access_token={_accessToken}&{args}");
            if (!response.IsSuccessStatusCode)
                return default(T);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(result);
        }

        private static StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}