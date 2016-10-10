using OnlineShoppingWeb.Enities;
using System.Collections.Generic;

namespace OnlineShoppingWeb.Services
{
    public interface IShoppingCartData
    {
        IEnumerable<ShoppingCart> GetAll();
        IEnumerable<ShoppingCart> GetAllByUser(User User);
        int GetUserTotalSavedItems(string UserId);
        bool IsProductInCart(int ProductId, string UserId);
    }
}
