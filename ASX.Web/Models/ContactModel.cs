using System.ComponentModel.DataAnnotations;

namespace ASX.Web.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }
    }
}