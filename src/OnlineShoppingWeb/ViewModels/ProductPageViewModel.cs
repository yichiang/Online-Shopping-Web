﻿using OnlineShoppingWeb.Enities;
using OnlineShoppingWeb.Services;
using System.Collections.Generic;


namespace OnlineShoppingWeb.ViewModels
{
    public class ProductPageViewModel
    {

        public ProductPageViewModel()
        {
            IsListAreaVisible = true;
            IsSearchAreaVisible = true;
            IsAddPhoneFormAreaVisible = false;
            IsAddLaptopFormAreaVisible = false;
            IsEditLaptopFormAreaVisible = false;
            IsEditPhoneFormAreaVisible = false;
            DisplayList = 10;
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
        public bool IsListAreaVisible { get; set; }
        public bool IsSearchAreaVisible { get; set; }
        public bool IsAddPhoneFormAreaVisible { get; set; }
        public bool IsAddLaptopFormAreaVisible { get; set; }
        public bool IsEditLaptopFormAreaVisible { get; set; }
        public bool IsEditPhoneFormAreaVisible { get; set; }
        public int DisplayList { get; set; }

    }
}
