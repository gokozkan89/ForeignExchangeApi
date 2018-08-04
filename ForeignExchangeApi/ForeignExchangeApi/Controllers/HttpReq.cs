using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ForeignExchangeApi.Controllers
{
    public class HttpReq
    {
        private static readonly HttpClient client = new HttpClient();
        public HttpReq() { }
        public async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var stringTask = client.GetStringAsync("https://api.github.com/users/gokozkan89/repos");

            var msg = await stringTask;
        }
    }
}