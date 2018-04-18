using HelloCICD.Web.Models;
using HelloCICD.Web.Interfaces;

namespace HelloCICD.Web.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        public TotalResult GetShoppingCartDetails(ShoppingCart shoppingCart)
        {
            var totalResult = new TotalResult
            {
                SelectedProducts = shoppingCart.CartProducts
            };

            foreach (var product in shoppingCart.CartProducts)
            {
                totalResult.TotalPrice += product.Price;
            }

            //apply rebate of 10% if total exceeds 20M
            if (totalResult.TotalPrice > 20M)
            {
                totalResult.RebateValue = totalResult.TotalPrice * 0.1M;
                totalResult.DiscountedPrice = totalResult.TotalPrice - totalResult.RebateValue;
            }

            return totalResult;
        }
    }
}
