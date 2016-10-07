using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingWeb.ViewModels
{
    public class RegisterViewModel
    {
        [Required,MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password),Compare("Password")]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }
        public string RoleName { get; set; }
        public List<string> RoleNames { get; set; }

    }
}
