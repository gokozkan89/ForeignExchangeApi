﻿using Newtonsoft.Json;


namespace ForeignExchangeApi.Models
{
    public class Currency
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("buyPrice")]
        public double Buying { get; set; }

        [JsonProperty("sellPrice")]
        public double Selling { get; set; }

        [JsonProperty("dailyChange")]
        public double ChangeRate { get; set; }

        [JsonProperty("lastUpdateDate")]
        public string UpdateDate { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}



