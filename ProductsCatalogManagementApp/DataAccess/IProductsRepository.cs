using ProductsCatalogManagementApp.Entities;
using System.Collections.Generic;

namespace ProductsCatalogManagementApp.DataAccess
{
    public interface IProductsRepository
    {


        void Create(Product product);
        void Delete(int id);
        void Edit(Product product);

        List<Product> GetAll();
        Product GetById(int id);

        Product GetCostliestProduct();

        Product GetCheapestProduct();

        int GetProductCount();

    }
}
