using System.ComponentModel.DataAnnotations;

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
