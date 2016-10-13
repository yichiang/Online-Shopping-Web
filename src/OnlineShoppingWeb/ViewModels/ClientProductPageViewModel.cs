using OnlineShoppingWeb.Enities;
using System.Collections.Generic;


namespace OnlineShoppingWeb.ViewModels
{
    public class ClientProductPageViewModel : ProductPageViewModel
    {

        public ClientProductPageViewModel() : base()
        {
        }

        public string MailEmailAddress { get; set; }
        public int SaveToCartProductId { get; set; }
        public string ProductType { get; set; }
        public ProductReview ProductReview { get; set; }

    }
}
