using System.Collections.Generic;

namespace HelloCICD.Web.Models
{
    public class TotalResult
    {
        public decimal TotalPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public decimal RebateValue { get; set; }
        public IEnumerable<Product> SelectedProducts { get; set; }
    }
}
