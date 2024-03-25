using System.ComponentModel.DataAnnotations;

namespace KnowledgeHubPortal.WebApplication.Models.Domain.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Please enter category name")]
        [MinLength(5, ErrorMessage = "Please enter atleast 5 charactors")]
        [MaxLength(100)]
        public string CategoryName { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(500)]
        public string CategoryDescription { get; set; }
    }
}