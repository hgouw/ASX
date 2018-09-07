using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;

namespace ASX.Web.Models
{
    public class GoogleChartModel
    {
        [Display(Name = "Industry")]
        public int IndustryGroup { get; set; }
        [Display(Name = "Company")]
        public int Company { get; set; }
        public GoogleChart GoogleChart { get; set; }
    }
}