using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ForeignExchangeApi.Services
{
    public class HttpClientService
    {
        public Dictionary<string,string> Parameters { get; set; }

        public string BaseUrl { get; set; } = "https://www.doviz.com/api/v1/";

        private readonly HttpClient httpClient;

        public HttpClientService()
        {
            this.httpClient = new HttpClient();
        }

        public T Get<T>(string endPointName)
        {
            var url = BaseUrl + endPointName;
            var getResponse = httpClient.GetAsync(url).Result;
            string data = getResponse.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
