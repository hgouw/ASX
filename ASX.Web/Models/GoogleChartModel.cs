using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;

namespace ASX.Web.Models
{
    public class GoogleChartModel
    {
        [Display(Name = "Industry")]
        public string IndustryGroup { get; set; }
        [Display(Name = "Company")]
        public string CompanyCode { get; set; }
        public List<SharePrice> SharePrices { get; set; }
    }

    public class SharePrice
    {
        public DateTime Date { get; set; }
        public Decimal Price { get; set; }
    }

}