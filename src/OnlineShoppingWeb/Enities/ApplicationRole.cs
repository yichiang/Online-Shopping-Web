using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingWeb.Enities
{
    public class ApplicationRole : IdentityRole
    {
        [Required]
        [StringLength(50)]
        public int Phone { get; set; }
        public string WorkTitle { get; set; }

    }
}
