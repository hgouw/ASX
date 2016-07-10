using System;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;
using ASX.Web.Models;

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
                    using (var msg = new MailMessage())
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append("Name: " + contact.Name);
                        sb.Append(Environment.NewLine);
                        sb.Append("Email: " + contact.Email);
                        sb.Append(Environment.NewLine);
                        sb.Append("Phone: " + contact.Phone);
                        sb.Append(Environment.NewLine);
                        sb.Append("Message: " + contact.Message);

                        msg.From = new MailAddress(contact.Email.ToString());
                        msg.To.Add("hermangouw@gmail.com");
                        msg.Subject = "Contact Me";
                        msg.IsBodyHtml = false;
                        msg.Body = sb.ToString();

                        SmtpClient client = new SmtpClient();
                        client.Host = "smtp.gmail.com";
                        client.Port = 465;
                        client.EnableSsl = true;
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.Credentials = new System.Net.NetworkCredential("hermangouw@gmail.com", "f3k2fh0OIy?cZ");
                        client.Send(msg);
                    }

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