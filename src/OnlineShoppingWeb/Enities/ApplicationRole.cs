using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingWeb.Enities
{
    public class ApplicationRole : IdentityRole
    {
        [Required]
        [StringLength(50)]
        public int Phone { get; set; }
        public string WorkTitle { get; set; }

        public ApplicationRole(string name) :base(name)
        {

        }
    }
}
