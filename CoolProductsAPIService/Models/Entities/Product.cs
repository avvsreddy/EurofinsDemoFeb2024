using System.ComponentModel.DataAnnotations;

namespace CoolProductsAPIService.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public string Brand { get; set; }
        public string Country { get; set; }
        public bool IsInStock { get; set; }

    }


    public class ProductV2
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Rate { get; set; }
        public string Brand { get; set; }
        public string Country { get; set; }
        public bool IsInStock { get; set; }

    }
}