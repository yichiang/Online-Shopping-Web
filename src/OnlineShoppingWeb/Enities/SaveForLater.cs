using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingWeb.Enities
{
    public class SaveForLater
    {
        [Key]
        public int SaveForLaterId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Proudct { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
