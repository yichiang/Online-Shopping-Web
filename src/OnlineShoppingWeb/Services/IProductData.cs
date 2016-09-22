using OnlineShoppingWeb.Enities;
using System;
using System.Collections.Generic;

namespace OnlineShoppingWeb.Services
{
    public interface IProductData
    {
        IEnumerable<IProduct> GetAll();
        void AddNewProduct(IProduct newProduct);
    }
}
