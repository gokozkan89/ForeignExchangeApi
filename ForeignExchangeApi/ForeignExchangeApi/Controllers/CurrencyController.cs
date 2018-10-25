using FluentScheduler;
using ForeignExchangeApi.Models;
using ForeignExchangeApi.Services;
using ForeignExchangeApi.SignalR;
using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        [HttpPost("schedule")]
        public bool SchedulerStartStop(int Time, string Action) {
            CurrencySignal currencySignal = new CurrencySignal(currencyServices);
            var registry = new Registry();
            if (Action.ToLower() == "start") {
                JobManager.AddJob(() => currencySignal.SendCurrenciesValue(), (s) => s.ToRunNow().AndEvery(Time).Minutes());
                return true;
            } else if (Action.ToLower() == "stop") {
                JobManager.Stop();
                return true;
            } else {
                return false;
            }
        }

    }
}




