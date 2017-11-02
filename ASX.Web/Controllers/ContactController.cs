using System;
using System.Configuration;
using System.Web.Mvc;
using ASX.Web.Models;
using SendGrid.Helpers.Mail;

namespace ASX.Web.Controllers
{
    public class ContactController : Controller
    {
        [Route("Contact")]
        public ActionResult Default()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Default(ContactModel contact, bool IsCaptchaValid)
        {
            if (!IsCaptchaValid)
            {
                TempData["ReCaptchaError"] = "Please verify that you are not a robot.";
            }
            if (ModelState.IsValid && IsCaptchaValid)
            {
                try
                {
                    dynamic sendGrid = new SendGrid.SendGridAPIClient(ConfigurationManager.AppSettings["SendGridApiKey"], ConfigurationManager.AppSettings["SendGridUrl"]);
                    var from = new Email(contact.Email, contact.Name);
                    var to = new Email(ConfigurationManager.AppSettings["ToEmailAddress"], ConfigurationManager.AppSettings["ToName"]);
                    var subject = ConfigurationManager.AppSettings["Subject"];
                    var content = new Content("text/plain", contact.Message);
                    var mail = new Mail(from, subject, to, content);
                    dynamic response = sendGrid.client.mail.send.post(requestBody: mail.Get());
                    return View("Success");
                }
                catch (Exception ex)
                {
                    return View($"Error - {ex.Message}");
                }
            }
            return View();
        }
    }
}