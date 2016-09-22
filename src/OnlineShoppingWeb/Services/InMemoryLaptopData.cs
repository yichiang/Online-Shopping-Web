﻿using System;
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
            new Laptop { LaptopId=0,price=745.34M,Brand="Dell",Model="Inspirion5759",HardDriveSize="1TD",ScreenSize=17.3,AvgCustomerReview=3.4,HardDrive=HardDriveType.HHD,Condition=ConditionType.New,Processor=ProcessorType.IntelI7 },
            new Laptop { LaptopId=1,price=345.34M,Brand="AUSU",Model="a759",HardDriveSize="1TD",ScreenSize=15.6,AvgCustomerReview=3.4,HardDrive=HardDriveType.HHD,Condition=ConditionType.New,Processor=ProcessorType.IntelI5 },
            new Laptop { LaptopId=2,price=245.34M,Brand="LENOVO",Model="b",HardDriveSize="250GB",ScreenSize=13,AvgCustomerReview=4.4,HardDrive=HardDriveType.HHD,Condition=ConditionType.New,Processor=ProcessorType.IntelI5 }
        };
 

        public void AddNewProduct(IProduct newProduct)
        {
            Laptop newLaptop = (Laptop) newProduct;
            newLaptop.LaptopId = _allTestLaptop.Count;
            _allTestLaptop.Add(newLaptop);
        }

        public IEnumerable<IProduct> GetAll()
        {
            return _allTestLaptop;
        }
    }
}
