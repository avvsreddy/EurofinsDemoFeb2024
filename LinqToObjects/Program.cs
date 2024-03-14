using System;
using System.Collections.Generic;
using System.Linq;
namespace YourNamespace
{

    // select p.name, c.name from products p join categories c on p.categoryid = c.categoryid
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
    }


    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string Country { get; set; }

        public Category Category { get; set; }
        public Product()
        {

        }
        public Product(int productId, string name, decimal price, string brand, string country, Category c)
        {
            ProductID = productId;
            Name = name;
            Price = price;
            Brand = brand;
            Country = country;
            Category = c;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // get all products name and price
            var result = from p in GetProducts()
                         select new { Name = p.Name, Price = p.Price };


            foreach (var p in result)
            {
                //Console.WriteLine(p.Name + " " + p.Price);
            }


            // get product name and catagory name

            var result2 = from p in GetProducts()
                          select new { PName = p.Name, CName = p.Category.Name };

            foreach (var item in result2)
            {
                Console.WriteLine($"{item.PName}\t{item.CName}");
            }
        }

        public static List<Product> GetProducts()
        {
            Category c1 = new Category { CategoryID = 1, Name = "Furniture" };
            Category c2 = new Category { CategoryID = 2, Name = "Electronics" };
            Category c3 = new Category { CategoryID = 3, Name = "Cloths" };
            Category c4 = new Category { CategoryID = 4, Name = "Automobile" };

            List<Product> products = new List<Product>
                {
                new Product(1, "Out Chair", 5820.16m, "HomeGood", "Italy",c1),
                new Product(2, "Myself Shirt", 8726.51m, "TechBrand", "USA",c3),
                // Assuming continuation from previously added products...
                new Product(3, "Arm Shirt", 4221.29m, "FashionLine", "Germany",c3),
                new Product(4, "Whatever Chair", 6353.03m, "FashionLine", "China", c3),
                new Product(5, "Full Shirt", 2520.64m, "FashionLine", "Italy", c3),
                new Product(6, "Cut Camera", 2929.7m, "TechBrand", "Germany",c2),
                new Product(7, "Which Tablet", 4992.85m, "HomeGood", "France",c2),
                new Product(8, "Word Tablet", 4208.55m, "OutdoorEquip", "USA",c2),
                new Product(9, "Under Chair", 8840.16m, "OutdoorEquip", "USA",c1),
                new Product(10, "Lot Camera", 3367.11m, "TechBrand", "USA",c2),
                // Add as many products as needed
                new Product(47, "Five Laptop", 8199.98m, "FashionLine", "France",c2),
                new Product(48, "Travel Tire", 5985.09m, "AutoPart", "USA",c4),
                new Product(49, "Third Tablet", 568.34m, "AutoPart", "Italy",c4),
                // The last product added from the initial list
                new Product(50, "Wall Tablet", 1276.66m, "HomeGood", "Japan",c2)
            };
            return products;


        }

    }
}
