using HelloCICD.Web.Models;
using HelloCICD.Web.Services;
using System.Collections.Generic;
using Xunit;


namespace HelloCICD.UnitTests
{
    public class ShoppingCartServiceTests
    {
        private readonly ShoppingCartService shoppingCartService = new ShoppingCartService();


        private readonly TotalResult expectedTotalResult = new TotalResult
        {
            SelectedProducts = new List<Product>()
            {
              new Product { Name = "Prod1", Description = "Prod1", Price = 10M },
              new Product { Name = "Prod2", Description = "Prod2", Price = 15.99M }
            },
            DiscountedPrice = 23.391M,
            RebateValue = 2.599M,
            TotalPrice = 25.99M
        };

        [Fact]
        public void GetShoppingCartDetails_ValidRequest_ShouldNotApplyRebate()
        {
            var shoppingCart = new ShoppingCart
            {
                CartId = "0000-0000-0000-0000",
                CartProducts = new List<Product>
                {
                  new Product { Name = "Prod1", Description = "Prod1", Price = 2M },
                  new Product { Name = "Prod2", Description = "Prod2", Price = 3M }
                }
            };

            var totalResult = shoppingCartService.GetShoppingCartDetails(shoppingCart);

            Assert.Equal(0, totalResult.RebateValue);
        }


        [Fact]
        public void GetShoppingCartDetails_ValidRequest_ShouldReturnCorrectTotalResult()
        {
            var shoppingCart = new ShoppingCart
            {
                CartId = "0000-0000-0000-0000",
                CartProducts = new List<Product>
                {
                  new Product { Name = "Prod1", Description = "Prod1", Price = 10M },
                  new Product { Name = "Prod2", Description = "Prod2", Price = 15.99M }
                }
            };

            var totalResult = shoppingCartService.GetShoppingCartDetails(shoppingCart);

            Assert.Equal(totalResult.DiscountedPrice, expectedTotalResult.DiscountedPrice);
            Assert.Equal(totalResult.TotalPrice, expectedTotalResult.TotalPrice);
            Assert.Equal(totalResult.RebateValue, expectedTotalResult.RebateValue);
        }
    }
}
