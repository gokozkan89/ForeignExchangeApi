using FluentScheduler;
using ForeignExchangeApi.Models;
using ForeignExchangeApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForeignExchangeApi.Controllers {
    [Route("api/v1")]
    [ApiController]
    public class CurrencyController : Controller {
        private readonly IHttpClientServices currencyServices;
        public CurrencyController(IHttpClientServices currencyServices) {
            this.currencyServices = currencyServices;
        }
        [Route("{Commodies}/{Code}/{Time}")]
        [HttpGet]
        public JsonResult LatestCurrency(string Commodies, string Code, string Time) {
            var endPoint = string.Concat(Commodies, "/", Code, "/", Time);
            if (Time.ToLower() == "latest") {
                if (Code.ToLower() == "all") {
                    return Json(currencyServices.GetList<Currency>(endPoint));
                } else {
                    return Json(currencyServices.Get<Currency>(endPoint));
                }
            } else if (Time.ToLower() == "daily") {
                return Json(currencyServices.GetList<CurrencyDaily>(endPoint));
            }
            return Json("");
        }
        

    }
}




