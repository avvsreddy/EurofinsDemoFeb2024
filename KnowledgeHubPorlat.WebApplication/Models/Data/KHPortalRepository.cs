using KnowledgeHubPortal.WebApplication.Models.Domain;
using KnowledgeHubPortal.WebApplication.Models.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeHubPortal.WebApplication.Models.Data
{
    public class KHPortalRepository : IKHPortalRepository
    {
        KnowledgeHubDbContext db = new KnowledgeHubDbContext(); // DIP
        public List<Article> BrowseArticles()
        {
            return db.Articles.Where(a => a.IsApproved).ToList();
        }

        public void CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}