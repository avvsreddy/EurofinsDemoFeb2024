using CoolProductsAPIService.Models.DataAccess;
using CoolProductsAPIService.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CoolProductsAPIService.Controllers
{
    public class CoolProductsController : ApiController
    {
        // design the endpoint / uri
        // get endpoint

        // GET ...api/coolproducts - collection of products

        ProductsDbContext db = new ProductsDbContext(); // DIP - DOTO: use repository insted of context

        [HttpGet]
        public List<Product> GetProducts()
        {
            // fetch all products from model and return
            var allProducts = db.Products.ToList();
            return allProducts;
        }


    }
}
