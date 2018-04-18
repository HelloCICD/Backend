using HelloCICD.Web.Interfaces;
using HelloCICD.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloCICD.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public readonly IProductService productService;
        public readonly IShoppingCartService shoppingCartService;

        public ValuesController(IProductService productService, IShoppingCartService shoppingCartService)
        {
            this.productService = productService;
            this.shoppingCartService = shoppingCartService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = productService.GetProductDetails(id);

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody]ShoppingCart shoppingCart)
        {
            var totalResult = shoppingCartService.GetShoppingCartDetails(shoppingCart);

            return Ok(totalResult);
        }
    }
}
