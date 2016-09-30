using OnlineShoppingWeb.Enities;
using System;
using System.Collections.Generic;

namespace OnlineShoppingWeb.Services
{
    public interface IProductData
    {
        IEnumerable<Product> GetAll();
        void AddNewProduct(Product newProduct);
        IEnumerable<Product> GetProductsbySubDepartment(int SubDepartmentId);
        void DeleteProduct(int ProductId);
        Product FindProductById(int ProductId);

    }
}
