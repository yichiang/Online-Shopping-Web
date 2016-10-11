using OnlineShoppingWeb.Enities;
using System.Collections.Generic;

namespace OnlineShoppingWeb.Services
{
    public interface IProductData
    {
        IEnumerable<Product> GetAll();
        IEnumerable<Product> SearchByTitle(string SearchTitle);
        void AddNewProduct(Product newProduct);
        IEnumerable<Product> GetProductsbySubDepartment(int SubDepartmentId);
        void DeleteProduct(int ProductId);
        Product FindProductById(int ProductId);
        Product Edit(Product EditProduct);

        void EditQty(Product EditProduct);
        IEnumerable<Product> GetPorductsofNum(int SkipNum, int TakeNum);

        void SaveToCart(int ProductId, string UserId);

        Product FindProductByIdIncludedReview(int ProductId);
        void SaveReview(ProductReview ProductReview);
    }
}
