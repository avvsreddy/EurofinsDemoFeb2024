using CoolProductsAPIService.Models.DataAccess;
using CoolProductsAPIService.Models.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
//using System.Web.Http.OData;

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
        [EnableQuery]
        //AllowedQueryOptions = System.Web.Http.OData.Query.AllowedQueryOptions.Select | System.Web.Http.OData.Query.AllowedQueryOptions.OrderBy)]
        public IQueryable<Product> GetProducts()
        {
            // fetch all products from model and return
            var allProducts = db.Products.AsQueryable<Product>();
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


        //// client: get all products based on category
        //// URI - GET .../api/coolproducts/category/mobiles
        [HttpGet]
        [Route("category/{category}")]
        public List<Product> GetProductsByCategory(string category)
        {
            var products = db.Products.Where(p => p.Category.Contains(category)).ToList();
            return products;
        }


        //// Lab 1: Get all products based on country
        //// todo: design the url - implement the endpoint - test the endpoint - with http best practics

        [HttpGet]
        [Route("country/{country}")]
        public List<Product> GetProductsByCountry(string country)
        {
            return db.Products.Where(p => p.Country.Contains(country)).ToList();
        }

        //// Lab 2: Get all products based on brand
        [HttpGet]
        [Route("brand/{brand}")]
        public List<Product> GetProductsByBrand(string brand)
        {
            return db.Products.Where(p => p.Brand.Contains(brand)).ToList();
        }

        //// Lab 3: Get one cheapest product
        [HttpGet]
        [Route("cheapest")]
        public Product GetCheapestProduct()
        {
            return db.Products.OrderBy(p => p.Price).FirstOrDefault();
        }

        //// Lab 4: Get one costliest product

        [HttpGet]
        [Route("costliest")]
        public Product GetCostliestProduct()
        {
            return db.Products.OrderByDescending(p => p.Price).FirstOrDefault();
        }
        //// Lab 5: Get all products the price between min and max - 50000 100000

        //// ... /min/1000/max/5000
        [HttpGet]
        [Route("min/{min}/max/{max}")]
        public List<Product> GetProductsByPriceRange(int min, int max)
        {
            return db.Products.Where(p => p.Price >= min && p.Price <= max).ToList();
        }
        //// Lab 6: Get product based on the name

        [HttpGet]
        [Route("name/{name}")]
        public List<Product> GetProductsByName(string name)
        {
            return db.Products.Where(p => p.Name.Contains(name)).ToList();
        }
        //// Lab 7: GEt all products in the stock
        [HttpGet]
        [Route("instock")]
        public List<Product> GetProductsByAvailability()
        {
            return db.Products.Where(p => p.IsInStock).ToList();
        }


        // end point for adding new data 

        [HttpPost]
        public IHttpActionResult Post([FromBody] Product product)
        {
            // validate
            if (product == null)
            {
                return BadRequest("Invalid or empty product details posted");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid product details posted");
            }

            db.Products.Add(product);
            db.SaveChanges();

            // return status code 201 + location + saved data
            return Created($"/api/products/{product.Id}", product);
        }
        // .../api/coolproducts/1
        // Delete endpoint
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            // is product found
            var productToDel = db.Products.Find(id);
            if (productToDel == null)
            {
                //return NotFound();
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
            }
            db.Products.Remove(productToDel);
            db.SaveChanges();
            var res = Request.CreateResponse(System.Net.HttpStatusCode.OK);
            res.Headers.Add("API-Verion", "1");
            return res;

            //var response = Request.CreateResponse(HttpStatusCode.OK);//.Headers.Add("API-Version", "1");
            //return Ok();
            //response.Headers.Add("API-Version", "1");
            //return Ok(response);
        }

        // edit
        [HttpPut]
        public IHttpActionResult EditProduct([FromBody] Product product)
        {
            // validate
            if (product == null)
            {
                return BadRequest("Invalid or empty product details posted");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid product details posted");
            }

            //db.Products.Add(product);
            db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return Ok();
        }

        [HttpPatch]
        //[Route("patch")]
        public IHttpActionResult PatchProduct(int id, Delta<Product> patch)
        {
            var product = db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return BadRequest("Product not found");
            }

            patch.Patch(product); // Apply changes from the patch to the product

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid product details posted");
            }


            db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return Ok();
        }

    }
}



namespace CoolProductsAPIService.Controllers
{
    //[RoutePrefix("api/v2/coolproducts")]
    public class CoolProductV2Controller : ApiController
    {
        // design the endpoint / uri
        // get endpoint

        // GET ...api/coolproducts - collection of products

        ProductsDbContext db = new ProductsDbContext(); // DIP - DOTO: use repository insted of context

        // get all products

        [HttpGet]
        [Route("api/v2/coolproducts")]
        [EnableQuery]
        //AllowedQueryOptions = System.Web.Http.OData.Query.AllowedQueryOptions.Select | System.Web.Http.OData.Query.AllowedQueryOptions.OrderBy)]
        public IQueryable<Product> GetProducts()
        {
            // fetch all products from model and return
            var allProducts = db.Products.AsQueryable<Product>();
            return allProducts;
        }

        //client:  get product by id
        // GET .../api/coolproducts/123
        [Route("api/v2/coolproducts/{id}")]

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


        //// client: get all products based on category
        //// URI - GET .../api/coolproducts/category/mobiles
        [HttpGet]
        [Route("api/v2/coolproducts/category/{category}")]
        public List<Product> GetProductsByCategory(string category)
        {
            var products = db.Products.Where(p => p.Category.Contains(category)).ToList();
            return products;
        }


        //// Lab 1: Get all products based on country
        //// todo: design the url - implement the endpoint - test the endpoint - with http best practics

        [HttpGet]
        [Route("api/v2/coolproducts/country/{country}")]
        public List<Product> GetProductsByCountry(string country)
        {
            return db.Products.Where(p => p.Country.Contains(country)).ToList();
        }

        //// Lab 2: Get all products based on brand
        [HttpGet]
        [Route("api/v2/coolproducts/brand/{brand}")]
        public List<Product> GetProductsByBrand(string brand)
        {
            return db.Products.Where(p => p.Brand.Contains(brand)).ToList();
        }

        //// Lab 3: Get one cheapest product
        [HttpGet]
        [Route("api/v2/coolproducts/cheapest")]
        public Product GetCheapestProduct()
        {
            return db.Products.OrderBy(p => p.Price).FirstOrDefault();
        }

        //// Lab 4: Get one costliest product

        [HttpGet]
        [Route("api/v2/coolproducts/costliest")]
        public Product GetCostliestProduct()
        {
            return db.Products.OrderByDescending(p => p.Price).FirstOrDefault();
        }
        //// Lab 5: Get all products the price between min and max - 50000 100000

        //// ... /min/1000/max/5000
        [HttpGet]
        [Route("api/v2/coolproducts/min/{min}/max/{max}")]
        public List<Product> GetProductsByPriceRange(int min, int max)
        {
            return db.Products.Where(p => p.Price >= min && p.Price <= max).ToList();
        }
        //// Lab 6: Get product based on the name

        [HttpGet]
        [Route("api/v2/coolproducts/name/{name}")]
        public List<Product> GetProductsByName(string name)
        {
            return db.Products.Where(p => p.Name.Contains(name)).ToList();
        }
        //// Lab 7: GEt all products in the stock
        [HttpGet]
        [Route("api/v2/coolproducts/instock")]
        public List<Product> GetProductsByAvailability()
        {
            return db.Products.Where(p => p.IsInStock).ToList();
        }


        // end point for adding new data 

        [HttpPost]
        [Route("api/v2/coolproducts")]
        public IHttpActionResult Post([FromBody] Product product)
        {
            // validate
            if (product == null)
            {
                return BadRequest("Invalid or empty product details posted");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid product details posted");
            }

            db.Products.Add(product);
            db.SaveChanges();

            // return status code 201 + location + saved data
            return Created($"/api/products/{product.Id}", product);
        }
        // .../api/coolproducts/1
        // Delete endpoint
        [HttpDelete]
        [Route("api/v2/coolproducts")]
        public HttpResponseMessage Delete(int id)
        {
            // is product found
            var productToDel = db.Products.Find(id);
            if (productToDel == null)
            {
                //return NotFound();
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
            }
            db.Products.Remove(productToDel);
            db.SaveChanges();
            var res = Request.CreateResponse(System.Net.HttpStatusCode.OK);
            res.Headers.Add("API-Verion", "1");
            return res;

            //var response = Request.CreateResponse(HttpStatusCode.OK);//.Headers.Add("API-Version", "1");
            //return Ok();
            //response.Headers.Add("API-Version", "1");
            //return Ok(response);
        }

        // edit
        [HttpPut]
        [Route("api/v2/coolproducts")]
        public IHttpActionResult EditProduct([FromBody] Product product)
        {
            // validate
            if (product == null)
            {
                return BadRequest("Invalid or empty product details posted");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid product details posted");
            }

            //db.Products.Add(product);
            db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return Ok();
        }

        [HttpPatch]
        [Route("api/v2/coolproducts")]
        //[Route("patch")]
        public IHttpActionResult PatchProduct(int id, Delta<Product> patch)
        {
            var product = db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return BadRequest("Product not found");
            }

            patch.Patch(product); // Apply changes from the patch to the product

            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid product details posted");
            }


            db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return Ok();
        }

    }
}

