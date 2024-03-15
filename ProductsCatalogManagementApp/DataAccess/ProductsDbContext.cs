using ProductsCatalogManagementApp.Entities;
using System.Data.Entity;

namespace ProductsCatalogManagementApp.DataAccess
{
    public class ProductsDbContext : DbContext
    {
        // Configure-Map the Database
        public ProductsDbContext() : base("defaultConnection")
        {

        }


        // Configure-Map the Entities - Tables

        public DbSet<Product> Products { get; set; }

    }
}
