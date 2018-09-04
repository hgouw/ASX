using System.Collections.Generic;

namespace System.Web.Helpers
{
    public class GoogleChart
    {
        public List<SharePrice> SharePrices { get; set; }
    }

    public class SharePrice
    {
        public DateTime Date { get; set; }
        public Decimal Price { get; set; }
    }
}