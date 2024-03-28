using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class NewProductRepo : IProductRepo
    {
        public List<Product> GetProducts()
        {
            return new List<Product> { new Product { ProductId = 1010, Name = "New product", Price = 1000 } };
        }
    }
}