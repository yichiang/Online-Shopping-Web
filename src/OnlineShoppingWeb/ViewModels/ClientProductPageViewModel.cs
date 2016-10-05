﻿using OnlineShoppingWeb.Enities;
using OnlineShoppingWeb.Services;
using System.Collections.Generic;


namespace OnlineShoppingWeb.ViewModels
{
    public class ClientProductPageViewModel
    {

        public ClientProductPageViewModel()
        {
            IsListAreaVisible = true;
            IsSearchAreaVisible = true;
            IsAddPhoneFormAreaVisible = false;
            IsAddLaptopFormAreaVisible = false;
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
    }
}