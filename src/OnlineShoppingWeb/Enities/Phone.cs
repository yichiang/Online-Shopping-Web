using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingWeb.Enities
{
    public class Phone : Product
    {
 
    
        [Display(Name = "Screen Size")]
        public double ScreenSize { get; set; }
        public string Carrier { get; set; }
    }
}
