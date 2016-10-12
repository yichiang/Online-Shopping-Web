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
        void ModifyQty(ShoppingCart product, int newQty);
        ShoppingCart FindCartProductById(int ProductId, string UserId);
        void Delete(ShoppingCart ShoppingCartproduct);
        SaveForLater SaveForLater(int ProductId, string userId);
        IEnumerable<SaveForLater> GetAllSaveForLaterByUserId(string UserId);
        void DelteSaveToList(int ProductId, string userId);
        bool CheckIsExistedInList(int ProductId, string userId);
        SaveForLater GetSaveForLater(int ProductId, string userId);


    }
}
