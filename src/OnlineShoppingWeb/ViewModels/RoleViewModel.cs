using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using OnlineShoppingWeb.Enities;
using System.Collections.Generic;
using System.Linq;

namespace OnlineShoppingWeb.ViewModels
{
    public class RoleViewModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<string> GetUserHasRoles(IEnumerable<IdentityUserRole<string>> allUserRoles, IEnumerable<IdentityRole> roles)
        {
            roles = roles.ToList();
            List<string> allroles = new List<string>();
            foreach(var userRole in allUserRoles)
            {
               
                  foreach (var role in roles)
                  {
                    if (role.Id == userRole.RoleId)
                    {
                        allroles.Add(role.Name);
                    }
                  }

                
            }
            return allroles;
        }
    }
}
