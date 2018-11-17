using FluentScheduler;
using ForeignExchangeApi.Handlers;
using ForeignExchangeApi.Models;
using ForeignExchangeApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ForeignExchangeApi.Controllers {
    [Route("api/v1")]
    [ApiController]
    public class CurrencyController : Controller {
        private readonly IHttpClientServices currencyServices;
        private readonly IMemoryCache memoryCache;
        private readonly CurrenciesHandler currenciesHandler;
        public CurrencyController(IHttpClientServices currencyServices,CurrenciesHandler currenciesHandler,IMemoryCache memoryCache) {
            this.currencyServices = currencyServices;
            this.currenciesHandler = currenciesHandler;
            this.memoryCache = memoryCache;
        }
        [Route("{Commodies}/{Code}/{Time}")]
        [HttpGet]
        public JsonResult LatestCurrency(string Commodies, string Code, string Time) {
            var endPoint = string.Concat(Commodies, "/", Code, "/", Time);
            if (Time.ToLower() == "latest") {
                if (Code.ToLower() == "all") {
                    
                    if (memoryCache.Get(Commodies+Code+Time)!=null) {
                        return Json(memoryCache.Get(Commodies + Code + Time));
                    } else {
                        var result = currencyServices.GetList<Currency>(endPoint);
                        memoryCache.Set(Commodies + Code + Time, result,TimeSpan.FromSeconds(20));
                        return Json(result);
                    }
                       
                } else {
                    if (memoryCache.Get(Commodies + Code + Time) != null) {
                        return Json(memoryCache.Get(Commodies + Code + Time));
                    } else {
                        var result = currencyServices.Get<Currency>(endPoint);
                        memoryCache.Set(Commodies + Code + Time, result, TimeSpan.FromSeconds(20));
                        return Json(result);
                    }
                }
            } else if (Time.ToLower() == "daily") {
                return Json(currencyServices.GetList<CurrencyDaily>(endPoint));
            }
            return Json("");
        }
        [Route("schedule")]
        [HttpPost]
        public void Schedule(string action) {
            if (action.ToLower() == "start") {

                JobManager.AddJob(() => sendCurrencies(), (s) => s.ToRunNow().AndEvery(1).Seconds());

            } else if (action.ToLower()== "stop") {
                JobManager.Stop();
            }
        }
        private void sendCurrencies() {
            var result = currencyServices.GetList<Currency>("currencies/all/latest");
            currenciesHandler.SendMessageToAllAsync(JsonConvert.SerializeObject(result)).Wait();
        }
        

    }
}




