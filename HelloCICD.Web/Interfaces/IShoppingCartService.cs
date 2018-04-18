using HelloCICD.Web.Models;

namespace HelloCICD.Web.Interfaces
{
    public interface IShoppingCartService
    {
        TotalResult GetShoppingCartDetails(ShoppingCart shoppingCart);
    }
}
