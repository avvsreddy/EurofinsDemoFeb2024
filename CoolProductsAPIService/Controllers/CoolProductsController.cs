using CoolProductsAPIService.Models.DataAccess;
using CoolProductsAPIService.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CoolProductsAPIService.Controllers
{
    [RoutePrefix("api/coolproducts")]
    public class CoolProductsController : ApiController
    {
        // design the endpoint / uri
        // get endpoint

        // GET ...api/coolproducts - collection of products

        ProductsDbContext db = new ProductsDbContext(); // DIP - DOTO: use repository insted of context

        // get all products

        [HttpGet]
        public List<Product> GetProducts()
        {
            // fetch all products from model and return
            var allProducts = db.Products.ToList();
            return allProducts;
        }

        //client:  get product by id
        // GET .../api/coolproducts/123
        public IHttpActionResult GetProductById(int id)
        {
            // fetch product by id
            var product = db.Products.Find(id);
            if (product == null)
            {
                // not found
                // return http status code 404
                return NotFound();
            }

            return Ok(product); // if found then return 200 with data
        }


        // client: get all products based on category
        // URI - GET .../api/coolproducts/category/mobiles
        [HttpGet]
        [Route("category/{category}")]
        public List<Product> GetProductsByCategory(string category)
        {
            var products = db.Products.Where(p => p.Category.Contains(category)).ToList();
            return products;
        }


        // Lab 1: Get all products based on country
        // todo: design the url - implement the endpoint - test the endpoint - with http best practics

        // Lab 2: Get all products based on brand

        // Lab 3: Get one cheapest product

        // Lab 4: Get one costliest product

        // Lab 5: Get all products the price between min and max - 50000 100000

        // Lab 6: Get product based on the name

        // Lab 7: GEt all products in the stock


    }
}
