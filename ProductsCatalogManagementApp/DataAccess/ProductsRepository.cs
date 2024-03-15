using ProductsCatalogManagementApp.Entities;
using System;
using System.Collections.Generic;

namespace ProductsCatalogManagementApp.DataAccess
{
    public class ProductsRepository : IProductsRepository
    {
        private ProductsDbContext db = new ProductsDbContext();
        public void Create(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetCheapestProduct()
        {
            throw new NotImplementedException();
        }

        public Product GetCostliestProduct()
        {
            throw new NotImplementedException();
        }

        public int GetProductCount()
        {
            throw new NotImplementedException();
        }
    }
}
