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
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public GoogleChart GoogleChart { get; set; }
    }
}