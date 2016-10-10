using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;

namespace OnlineShoppingWeb.ViewModels
{
    public class RoleViewModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
