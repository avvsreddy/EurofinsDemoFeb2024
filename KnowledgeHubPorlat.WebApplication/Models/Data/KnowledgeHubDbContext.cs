using KnowledgeHubPortal.WebApplication.Models.Domain.Entities;
using System.Data.Entity;

namespace KnowledgeHubPortal.WebApplication.Models.Data
{
    public class KnowledgeHubDbContext : DbContext
    {
        // configure database


        public KnowledgeHubDbContext() : base("DefaultConnection")
        {

        }


        // configure entities - tables
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}