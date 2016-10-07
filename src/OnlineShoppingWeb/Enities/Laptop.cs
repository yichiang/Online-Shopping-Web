using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingWeb.Enities
{
    public enum ProcessorType
    {
        unKnown,
        IntelI5,
        IntelI3,
        IntelI7,
        AMD

    }


    public enum HardDriveType
    {
        unKnown,
        HHD,
        SSD,
        Hybrid
    }
    [Table("Laptops")]
    public class Laptop : Product
    {
 

        [Display(Name = "Laptop Model")]
        public string LaptopModel { get; set; }
        [Required]
        [Display(Name = "Hard Drive Size")]
        public string HardDriveSize { get; set; }
        [Required]
        [Display(Name = "Screen Size")]
        public double ScreenSize { get; set; }
        [Display(Name = "Hard Drive Type")]
        public HardDriveType HardDrive { get; set; }
        public ProcessorType Processor { get; set; }

        //public virtual ICollection<HttpPostedFileBase> LaptopFiles { get; set; }

    }
}
