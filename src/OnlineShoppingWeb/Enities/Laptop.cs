
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
        public int LaptopId { get; set; }
        public decimal price { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string HardDriveSize { get; set; }
        public double ScreenSize { get; set; }
        public double AvgCustomerReview { get; set; }
        public HardDriveType HardDrive { get; set; }
        public ProcessorType Processor { get; set; }
        public ConditionType Condition { get; set; }
    }
}
