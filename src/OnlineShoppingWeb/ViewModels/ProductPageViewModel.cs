using Microsoft.AspNet.Http;
using OnlineShoppingWeb.Enities;
using System.Collections.Generic;


namespace OnlineShoppingWeb.ViewModels
{
    public class ProductPageViewModel
    {

        public ProductPageViewModel()
        {
            IsListAreaVisible = true;
            IsSearchAreaVisible = true;          
            TakeDisplayList = 5;
            SkipDisplayList = 0;
            EventCommand = "list";
        }
        public Laptop Laptop { get; set; }
        public Phone Phone { get; set; }
        public Product Product { get; set; }
        public string ProductSearchName { get; set; }
        public IEnumerable<Product> Products { get; set; }

        public IEnumerable<SubDepartment> SubDepartments { get; set; }
        public string EventCommand { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool IsSearchAreaVisible { get; set; }

        public int TakeDisplayList { get; set; }
        public int SkipDisplayList { get; set; }
        public int AllProductsCount { get; set; }
        public ICollection<IFormFile> UploadFile  { get; set; }

    }
}
