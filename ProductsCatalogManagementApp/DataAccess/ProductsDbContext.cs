using ProductsCatalogManagementApp.Entities;
using System.Data.Entity;

namespace ProductsCatalogManagementApp.DataAccess
{
    internal class ProductsDbContext : DbContext
    {
        // Configure-Map the Database
        public ProductsDbContext() : base("defaultConnection")
        {

        }


        // Configure-Map the Entities - Tables

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<Supplier> Suppliers { get; set; }

        //public DbSet<Customer> Customers { get; set; }

        public DbSet<Person> People { get; set; }

    }
}
