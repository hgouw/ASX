using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace ASX.Web
{
    public class ReCaptchaFilter : ActionFilterAttribute
    {
        public class JsonResponseObject
        {
            public bool Success { get; set; }
            [JsonProperty("error-codes")]
            public List<string> ErrorCodes { get; set; }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Request["g-recaptcha-response"] != null)
            {
                string privatekey = ConfigurationManager.AppSettings["ReCaptchaPrivateKey"];
                string response = filterContext.RequestContext.HttpContext.Request["g-recaptcha-response"];
                filterContext.ActionParameters["IsCaptchaValid"] = Validate(response, privatekey);
            }
        }

        public static bool Validate(string mainResponse, string privateKey)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("https://www.google.com/recaptcha/api/siteverify?secret=" + privateKey + "&response=" + mainResponse);
                var response = request.GetResponse();
                using (var stream = new StreamReader(response.GetResponseStream()))
                {
                    var jsonResponse = stream.ReadToEnd();
                    var jsonResponseObject = JsonConvert.DeserializeObject<JsonResponseObject>(jsonResponse);
                    return jsonResponseObject.Success;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}