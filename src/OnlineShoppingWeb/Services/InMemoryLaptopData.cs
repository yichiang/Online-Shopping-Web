using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShoppingWeb.Enities;

namespace OnlineShoppingWeb.Services
{

    public class InMemoryLaptopData : IProductData
    {

        private static List<Laptop> _allTestLaptop = new List<Laptop>
        {
            new Laptop { ProductId=1,Title="Gaming Laptop",Price=745.34M,Brand="Dell",LaptopModel="Inspirion5759",HardDriveSize="1TD",ScreenSize=17.3,AvgCustomerReview=3.4,HardDrive=HardDriveType.HHD,Condition=ConditionType.New,Processor=ProcessorType.IntelI7 },
            new Laptop { ProductId=2,Title="High Performance Laptop",Price=345.34M,Brand="AUSU",LaptopModel="a759",HardDriveSize="1TD",ScreenSize=15.6,AvgCustomerReview=3.4,HardDrive=HardDriveType.HHD,Condition=ConditionType.New,Processor=ProcessorType.IntelI5 },
            new Laptop { ProductId=3,Title="Good Laptop",Price=245.34M,Brand="LENOVO",LaptopModel="b",HardDriveSize="250GB",ScreenSize=13,AvgCustomerReview=4.4,HardDrive=HardDriveType.HHD,Condition=ConditionType.New,Processor=ProcessorType.IntelI5 }
        };
 

        public void AddNewProduct(IProduct newProduct)
        {
            Laptop newLaptop = (Laptop) newProduct;
            newLaptop.ProductId = _allTestLaptop.Count+1;
            _allTestLaptop.Add(newLaptop);
        }

        public IEnumerable<IProduct> GetAll()
        {
            return _allTestLaptop;
        }
    }
}
