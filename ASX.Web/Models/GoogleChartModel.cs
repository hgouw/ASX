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
    }
}