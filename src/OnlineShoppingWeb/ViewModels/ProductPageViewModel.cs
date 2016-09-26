using OnlineShoppingWeb.Enities;
using System.Collections.Generic;


namespace OnlineShoppingWeb.ViewModels
{
    public class ProductPageViewModel
    {
        public Laptop Laptop { get; set; }
        public IEnumerable<Laptop> Laptops { get; set; }
        public IEnumerable<SubDepartment> SubDepartments { get; set; }
    }
}
