using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace ForeignExchangeApi.Services
{
    public class HttpClientService : IHttpClientServices
    {
        public Dictionary<string, string> Parameters { get; set; }

        public string BaseUrl { get; set; } = "https://www.doviz.com/api/v/";

        private readonly HttpClient httpClient;

        public HttpClientService()
        {
            this.httpClient = new HttpClient();
        }

        public T Get<T>(string endPointName)
        {
            var url = BaseUrl + endPointName;
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Doviz");
            var getResponse = httpClient.GetAsync(url).Result;
            string data = getResponse.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(data);
        }
        public List<T> GetList<T>(string endPointName)
        {
            var url = BaseUrl + endPointName;
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Doviz");
            var getResponse = httpClient.GetAsync(url).Result;  
            string data = getResponse.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<T>>(data);
        }
    }
}
