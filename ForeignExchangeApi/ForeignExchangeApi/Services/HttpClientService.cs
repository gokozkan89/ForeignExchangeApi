using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace ForeignExchangeApi.Services
{
    public class HttpClientService : IHttpClientService
    {
        public Dictionary<string, string> Parameters { get; set; }

        public string BaseUrl { get; set; } = "https://api.canlidoviz.com/web/items?marketId=1&type=0";

        private readonly HttpClient httpClient;

        public HttpClientService()
        {
            this.httpClient = new HttpClient();
        }        
        public List<T> GetList<T>()
        {           
            var getResponse = httpClient.GetAsync(BaseUrl).Result;
            string data = getResponse.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<T>>(data);
        }
    }
}
