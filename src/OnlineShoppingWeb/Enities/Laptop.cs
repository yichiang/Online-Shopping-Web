using System.ComponentModel.DataAnnotations;

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

    public enum ConditionType
    {
        unKnown,
        New,
        Used,
        Refurbished
    }

    public enum HardDriveType
    {
        unKnown,
        HHD,
        SSD,
        Hybrid
    }
 
    public class Laptop : IProduct
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        public decimal Price { get; set; }
        [MaxLength(20)]
        public string Brand { get; set; }
        [Display(Name = "Laptop Model")]
        public string LaptopModel { get; set; }
        [Required]
        [Display(Name = "Hard Drive Size")]
        public string HardDriveSize { get; set; }
        [Required]
        [Display(Name = "Screen Size")]
        public double ScreenSize { get; set; }
        public double AvgCustomerReview { get; set; }
        [Display(Name = "Hard Drive Type")]
        public HardDriveType HardDrive { get; set; }
        public ProcessorType Processor { get; set; }
        public ConditionType Condition { get; set; }

        public SubDepartment SubDepartment { get; set; }

    }
}
