using System.Collections.Generic;

namespace WebApplication1.Models
{
    public interface IProductRepo
    {
        List<Product> GetProducts();
    }
}