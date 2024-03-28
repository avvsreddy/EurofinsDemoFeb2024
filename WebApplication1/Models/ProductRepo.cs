using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }

    public class ProductRepo : IProductRepo
    {
        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product {ProductId =1, Name ="Dell XPS", Price =78000},
                new Product {ProductId =2, Name ="IPhone", Price =78000},
                new Product {ProductId =3, Name ="Galaxy S24", Price =78000},
                new Product {ProductId =4, Name ="Dell XPS 2", Price =78000},
                new Product {ProductId =5, Name ="Dell XPS 3", Price =78000},
            };
        }
    }
}