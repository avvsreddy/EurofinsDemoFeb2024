using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KnowledgeHubPortal.WebApplication.Models.Domain.Entities
{
    public class Article
    {
        public int ArticleID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [Url]
        [DisplayName("URL Path")]
        public string UrlPath { get; set; }
        public string Description { get; set; }
        public string PostedBy { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public DateTime DatePosted { get; set; }
    }
}