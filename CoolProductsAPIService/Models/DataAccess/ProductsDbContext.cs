using CoolProductsAPIService.Models.Entities;
using System.Data.Entity;

namespace CoolProductsAPIService.Models.DataAccess
{
    public class ProductsDbContext : DbContext
    {
        // configure database

        public ProductsDbContext() : base("defaultConnection")
        {

        }

        // map entities with tables
        public DbSet<Product> Products { get; set; }


    }
}