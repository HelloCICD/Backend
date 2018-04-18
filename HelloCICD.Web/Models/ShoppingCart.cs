using System.Collections.Generic;

namespace HelloCICD.Web.Models
{
    public class ShoppingCart
    {
        public string CartId { get; set; }
        public IEnumerable<Product> CartProducts { get; set; }
    }
}
