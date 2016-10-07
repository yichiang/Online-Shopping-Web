using OnlineShoppingWeb.Enities;
using System.Collections.Generic;


namespace OnlineShoppingWeb.ViewModels
{
    public class ManagerProductViewModel: ProductPageViewModel
    {

        public ManagerProductViewModel():base()
        {

            IsAddPhoneFormAreaVisible = false;
            IsAddLaptopFormAreaVisible = false;
            IsEditLaptopFormAreaVisible = false;
            IsEditPhoneFormAreaVisible = false;

        }

        public bool IsAddPhoneFormAreaVisible { get; set; }
        public bool IsAddLaptopFormAreaVisible { get; set; }
        public bool IsEditLaptopFormAreaVisible { get; set; }
        public bool IsEditPhoneFormAreaVisible { get; set; }


    }
}
