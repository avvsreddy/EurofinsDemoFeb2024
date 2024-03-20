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
            // get all categories
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;
            // increase all products price with 1000 Rs.

            //var allProducts = db.Products.ToList();
            //foreach (var item in allProducts)
            //{
            //    item.Price += 1000;
            //}
            //db.SaveChanges();
            //Console.WriteLine("done");

            db.Database.ExecuteSqlCommand("update products set price = price + 1");


        }

        private static void CustAndSupAdd()
        {
            // add one customer and one supplier
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;

            Customer c = new Customer { CustType = "Gold", Discount = 12, Email = "cust1@shop.com", Location = "Bangalore", Mobile = "43423424", Name = "Customer 1" };

            Supplier s = new Supplier { Email = "sup1@abc.com", GST = "A2343", Location = "Bangalore", Mobile = "324234", Name = "Suppler 1", TradeLic = "Tx345r2" };

            db.People.Add(c);
            db.People.Add(s);
            db.SaveChanges();
        }

        private static void LazyNEgarLoading()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;
            // Select all prducts then display prodcut name and category name
            var allProducts = from p in db.Products //.Include("Category") // eagar loading
                              select p;

            foreach (var item in allProducts)
            {
                Console.WriteLine($"{item.Name}\t{item.Category.Name}");
            }
        }

        private static void InsertAndUpdate()
        {
            ProductsDbContext db = new ProductsDbContext();
            db.Database.Log = Console.WriteLine;
            // Add new category with existing products
            Category c = new Category() { Name = "Mobiles" };

            var p2 = db.Products.Find(2);
            var p3 = db.Products.Find(3);
            var p4 = db.Products.Find(4);

            p2.Category = c;
            p3.Category = c;
            p4.Category = c;

            db.Categories.Add(c);
            db.SaveChanges();

            Console.WriteLine("done");
        }

        private static void NewProductWithNewCategory(ProductsDbContext db1)
        {
            // Add a new product with new category

            Category cat = new Category { Name = "Laptops" };

            Product p = new Product { Name = "Dell XPS 13", Brand = "Dell", Country = "India", InStock = true, Price = 90000, Category = cat };

            db1.Products.Add(p);
            //db1.Categories.Add(cat);
            db1.SaveChanges();
        }

        private static void EditInDisconnected()
        {
            // edit in disconnected approach
            ProductsDbContext db1 = new ProductsDbContext();
            var productToEdit1 = db1.Products.Find(2);


            ProductsDbContext db2 = new ProductsDbContext();
            db2.Database.Log = Console.WriteLine;
            productToEdit1.Name = "IPhone 15 Pro Max -  again modified";
            db2.Entry(productToEdit1).State = System.Data.Entity.EntityState.Modified;
            db2.SaveChanges();
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
