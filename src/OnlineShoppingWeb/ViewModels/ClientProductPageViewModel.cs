using OnlineShoppingWeb.Enities;
using System.Collections.Generic;


namespace OnlineShoppingWeb.ViewModels
{
    public class ClientProductPageViewModel : ProductPageViewModel
    {

        public ClientProductPageViewModel() : base()
        {
        }


        public int SaveToCartProductId { get; set; }
        public string ProductType { get; set; }
   
    }
}
