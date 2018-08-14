using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignExchangeApi.Utilities
{
    public static class Extensions
    {
        public static DateTime ToDateTime(this long unixTimeStamps)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamps).ToLocalTime();
            return dtDateTime;
        }
    }
}
