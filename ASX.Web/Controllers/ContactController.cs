using System;
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
        public ActionResult Default(ContactModel contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var apiKey = "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";
                    dynamic sendGrid = new SendGrid.SendGridAPIClient(apiKey, "https://api.sendgrid.com");
                    var from = new Email(contact.Email, contact.Name);
                    var subject = "Message from hermangouw@net";
                    var to = new Email("hermangouw@gmail.com", "Herman Gouw");
                    var content = new Content("text/plain", contact.Message);
                    var mail = new Mail(from, subject, to, content);
                    dynamic response = sendGrid.client.mail.send.post(requestBody: mail.Get());
                    return View("Success");
                }
                catch (Exception ex)
                {
                    return View("Error");
                }
            }
            return View();
        }
    }
}