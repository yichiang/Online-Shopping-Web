using System;
using System.Collections.Generic;
using System.Linq;
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
 

        public void AddNewProduct(Product newProduct)
        {
            Laptop newLaptop = (Laptop) newProduct;
            newLaptop.ProductId = _allTestLaptop.Count+1;
            _allTestLaptop.Add(newLaptop);
        }

        public void DeleteProduct(int ProductId)
        {
            throw new NotImplementedException();
        }

        public Product Edit(Product EditProduct)
        {
            throw new NotImplementedException();
        }

        public void EditQty(Product EditProduct)
        {
            throw new NotImplementedException();
        }

        public Product FindProductById(int ProductId)
        {
            throw new NotImplementedException();
        }

        public Product FindProductByIdIncludedReview(int ProductId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            return _allTestLaptop;
        }

        public double GetAverageReview(int ProductId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetPorductsofNum(int SkipNum, int TakeNum)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProductsbySubDepartment(int SubDepartmentId)
        {
            return _allTestLaptop.Where(n => n.SubDepartmentId == SubDepartmentId).ToList();
        }

        public void SaveAverageScore(int ProductId, double newReviewScore)
        {
            throw new NotImplementedException();
        }

        public void SaveReview(ProductReview ProductReview)
        {
            throw new NotImplementedException();
        }

        public void SaveToCart(int ProductId, string UserId)
        {
            throw new NotImplementedException();
        }



        public IEnumerable<Product> SearchByTitle(string SearchTitle)
        {
            throw new NotImplementedException();
        }
    }
}
