using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsCatalogManagementApp.Entities
{
    //[Table("tbl_items")]
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        [MaxLength(100)]

        public string Name { get; set; }
        public int Price { get; set; }

        //[NotMapped]
        //public int SellingPrice { get; set; }
        public string Brand { get; set; }

        public string Country { get; set; }

        public bool InStock { get; set; }

        public virtual Category Category { get; set; }
        //[ForeignKey("Category")]
        //public int CategoryID { get; set; }
        public virtual List<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }


    public class Category
    {
        public int CategoryID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
    //[Table("Suppliers")] // TPT
    public class Supplier : Person
    {
        //public int SupplierID { get; set; }
        public string GST { get; set; }
        public string TradeLic { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }

    public abstract class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Location { get; set; }
    }
    //[Table("Customers")] // TPT
    class Customer : Person
    {
        public int Discount { get; set; }
        public string CustType { get; set; }
        public Address Address { get; set; }
    }

    [ComplexType]
    class Address
    {
        // dont provide ID property
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
    }
}
