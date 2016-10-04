using OnlineShoppingWeb.Enities;
using OnlineShoppingWeb.Services;
using System.Collections.Generic;


namespace OnlineShoppingWeb.ViewModels
{
    public class ProductPageViewModel
    {

        public ProductPageViewModel()
        {
            EventCommand = "list";
        }
        public Laptop Laptop { get; set; }
        public Phone Phone { get; set; }
        public Product Product { get; set; }
        public string ProductSearchName { get; set; }
        public IEnumerable<Laptop> Laptops { get; set; }
        public IEnumerable<Product> Products { get; set; }

        public IEnumerable<SubDepartment> SubDepartments { get; set; }
        public string EventCommand { get; set; }
      
    }
}
