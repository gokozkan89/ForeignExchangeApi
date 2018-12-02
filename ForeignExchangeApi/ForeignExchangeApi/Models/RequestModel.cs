using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignExchangeApi.Models
{
    public class RequestModel
    {
        public string Commodies { get; set; }
        public List<string> Codes { get; set; }
        public string Time { get; set; }
    }
}
