using ForeignExchangeApi.Models;
using ForeignExchangeApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForeignExchangeApi.Controllers {
    [Route("api/v1")]
    [ApiController]
    public class CurrencyController : Controller {
        private readonly HttpClientService httpClientService;
        public CurrencyController(HttpClientService httpClientService) {
            this.httpClientService = httpClientService;
        }

        [HttpGet("{Commodies}/{Code}/{Time}")]
        public JsonResult LatestCurrency(string Commodies, string Code, string Time) {
            var endPoint = string.Concat(Commodies, "/", Code, "/", Time);
            if (Time.ToLower() == "latest") {
                if (Code.ToLower() == "all") {
                    return Json(httpClientService.GetList<Currency>(endPoint));
                } else {
                    return Json(httpClientService.Get<Currency>(endPoint));
                }
            } else if (Time.ToLower() == "daily") {
                return Json(httpClientService.GetList<CurrencyDaily>(endPoint));
            }
            return Json("");
        }
    }
}




