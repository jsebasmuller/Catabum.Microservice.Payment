using System.Collections.Generic;
using Catabum.Payment.Domain.SeedWork;

namespace Catabum.Payment.Infrastructure.Models
{

    // View models used only to service queries
    public class Product : IDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public List<ProductDetail> ProductDetails { get; set; }
    }

    public class ProductDetail : IDto
    {
        public string DetailName { get; set; }
        public string DetailDescription { get; set; }
        public string DefinitionName { get; set; }
        public string DefinitionDescription { get; set; }
    }

    public class ProductCategory : IDto
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}
