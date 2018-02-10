using System;
using System.Configuration;
using System.Web.Mvc;
using ASX.Web.Models;
using SendGrid.Helpers.Mail;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

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
                    if (Convert.ToBoolean(ConfigurationManager.AppSettings["EmailEnabled"]))
                    {
                        // Send email via SendGrid
                        dynamic sendGrid = new SendGrid.SendGridAPIClient(ConfigurationManager.AppSettings["SendGridApiKey"], ConfigurationManager.AppSettings["SendGridUrl"]);
                        var from = new Email(contact.Email, contact.Name);
                        var to = new Email(ConfigurationManager.AppSettings["ToEmailAddress"], ConfigurationManager.AppSettings["ToName"]);
                        var subject = ConfigurationManager.AppSettings["Subject"];
                        var content = new Content("text/plain", contact.Message);
                        var mail = new Mail(from, subject, to, content);
                        dynamic response = sendGrid.client.mail.send.post(requestBody: mail.Get());
                    }

                    if (Convert.ToBoolean(ConfigurationManager.AppSettings["SMSEnabled"]))
                    {
                        // Send SMS via Twilio
                        var msg = $"From: {contact.Name} ({contact.Email}) - Message: {contact.Message}";
                        TwilioClient.Init(ConfigurationManager.AppSettings["TwilioAccountSid"], ConfigurationManager.AppSettings["TwilioAuthToken"]);
                        MessageResource.Create(to: new PhoneNumber(ConfigurationManager.AppSettings["ToMobileNumber"]), from: new PhoneNumber(ConfigurationManager.AppSettings["TwilioMobileNumber"]), body: msg);
                    }

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