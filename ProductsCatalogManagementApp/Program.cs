using ProductsCatalogManagementApp.DataAccess;
using ProductsCatalogManagementApp.Entities;
using System;
using System.Linq;

namespace ProductsCatalogManagementApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // PBI/User Story: As a user, I want to Save Product data into database, so that i can use it later
            // Task 1: Framework : EF - done
            // Task 2: Approach - Code First / DB First - done
            // Task 3: Setup/Install EF - done
            // Task 4: Create Entity Classess - done
            // Task 5: Configure EF - done
            // Task 6: Map Class to Table - done 
            // Task 7: Create Repository
            // Task 8: Create UI

            // GEt all products and display


        }

        private static void Edit()
        {
            ProductsDbContext db = new ProductsDbContext(); // opens a db connection

            db.Database.Log = Console.WriteLine;

            // get the entity to edit
            // modify the entity property data
            // save changes
            var productToEdit = db.Products.Find(2);
            productToEdit.Price = 100000;
            db.SaveChanges();
        }

        private static void Delete()
        {
            ProductsDbContext db = new ProductsDbContext(); // opens a db connection

            db.Database.Log = Console.WriteLine;

            // get the entity to remove
            var productToDel = (from p in db.Products
                                where p.ProductID == 1
                                select p).FirstOrDefault();


            db.Products.Remove(productToDel);
            db.SaveChanges();
        }

        private static void Select(ProductsDbContext db)
        {
            // Linq to Entities
            var allProducts = from p in db.Products
                              select p;



            Console.WriteLine("Product ID \t Name \t Price");
            foreach (var item in allProducts)
            {
                Console.WriteLine($"{item.ProductID}\t{item.Name}\t{item.Price}");
            }
        }

        private static void Insert()
        {
            // Write OO Code
            Product product = new Product();
            product.Name = "Galaxy 20S";
            product.Price = 69000;

            // DAL Layer is DBContext

            ProductsDbContext db = new ProductsDbContext(); // opens a db connection
            db.Database.Log = Console.WriteLine;

            db.Products.Add(product);
            db.SaveChanges();
            Console.WriteLine("Product Saved...");
        }
    }
}
