using KnowledgeHubPortal.WebApplication.Models.Domain.Entities;
using System.Collections.Generic;

namespace KnowledgeHubPortal.WebApplication.Models.Domain
{
    public interface IKHPortalRepository
    {
        void CreateCategory(Category category);



        List<Article> BrowseArticles();

    }
}
