using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingWeb.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string ComfirmationCode { get; set; }

    }
}
