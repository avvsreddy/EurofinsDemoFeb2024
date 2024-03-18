using ProductsCatalogManagementApp.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProductsCatalogManagementApp.DataAccess
{
    public class ProductsRepository : IProductsRepository
    {
        private ProductsDbContext db = new ProductsDbContext();
        public void Create(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Products.Remove(db.Products.Find(id));
            db.SaveChanges();
        }

        public void Edit(Product product)
        {
            db.Entry(product).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public Product GetById(int id)
        {
            return db.Products.Find(id);
        }

        public Product GetCheapestProduct()
        {
            var product = (from p in db.Products
                           orderby p.Price
                           select p).FirstOrDefault();
            return product;
        }

        public Product GetCostliestProduct()
        {
            return db.Products.OrderByDescending(p => p.Price).FirstOrDefault();
        }

        public int GetProductCount()
        {
            return db.Products.Count();
        }
    }
}
