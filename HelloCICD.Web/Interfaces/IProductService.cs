using System.Collections.Generic;
using HelloCICD.Web.Models;

namespace HelloCICD.Web.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProductDetails(int productId);
    }
}
