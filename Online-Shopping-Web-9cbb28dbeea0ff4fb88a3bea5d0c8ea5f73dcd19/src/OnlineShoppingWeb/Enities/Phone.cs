using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;

namespace OnlineShoppingWeb.Enities
{
    public class Phone : Product
    {
 
        [StringLength(20,MinimumLength =2)]
        public string Brand { get; set; }
       
        [Display(Name = "Screen Size")]
        public double ScreenSize { get; set; }
        public string Carrier { get; set; }
    }
}
