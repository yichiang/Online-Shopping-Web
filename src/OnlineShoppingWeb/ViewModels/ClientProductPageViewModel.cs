using OnlineShoppingWeb.Enities;
using System.Collections.Generic;


namespace OnlineShoppingWeb.ViewModels
{
    public class ClientProductPageViewModel : ProductPageViewModel
    {

        public ClientProductPageViewModel() : base()
        {
            IsDetailAreaVisible = false;
        }


        public bool IsDetailAreaVisible { get; set; }
        public int SaveToCartProductId { get; set; }
        public string ProductType { get; set; }
   
    }
}
