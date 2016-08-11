using System.Configuration;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ASX.Web
{
    public static class ExtensionMethods
    {
        public static IHtmlString ReCaptcha(this HtmlHelper helper)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<script src='https://www.google.com/recaptcha/api.js'></script>");
            sb.AppendLine("");
            sb.AppendLine("<div class=\"g-recaptcha\" data-sitekey=\"" + ConfigurationManager.AppSettings["RecaptchaPublicKey"] + "\"></div>");
            return MvcHtmlString.Create(sb.ToString());
        }

        //public static void ValidateReeCaptcha(this Controller controller)
        //{
        //    RecaptchaVerificationHelper recaptchaHelper = controller.GetRecaptchaVerificationHelper();
        //    if (String.IsNullOrEmpty(recaptchaHelper.Response))
        //    {
        //        controller.ModelState.AddModelError("", "Please enter the captcha code");
        //    }
        //    else
        //    {
        //        RecaptchaVerificationResult recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();
        //        if (recaptchaResult != RecaptchaVerificationResult.Success)
        //        {
        //            controller.ModelState.AddModelError("", "Please enter the correct captcha code");
        //        }
        //    }
        //}
    }
}