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

        public DbSet<Person> People { get; set; } // TPH

        // To configure TPC 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // TPC configuration

            modelBuilder.Entity<Customer>().Map(e => e.MapInheritedProperties());
            modelBuilder.Entity<Customer>().ToTable("Customers");

            modelBuilder.Entity<Supplier>().Map(e => e.MapInheritedProperties());
            modelBuilder.Entity<Supplier>().ToTable("Suppliers");

            // Map to Stored Procedures

            //modelBuilder.Entity<Product>().MapToStoredProcedures();

            modelBuilder.Types().Configure(t => t.MapToStoredProcedures());


        }
    }
}
