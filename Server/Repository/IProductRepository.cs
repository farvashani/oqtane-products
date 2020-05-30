using System.Collections.Generic;
using Tres.Products.Models;

namespace Tres.Products.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts(int ModuleId);
        Product GetProduct(int ProductId);
        Product AddProduct(Product Product);
        Product UpdateProduct(Product Product);
        void DeleteProduct(int ProductId);
    }
}
