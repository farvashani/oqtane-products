using System.Collections.Generic;
using System.Threading.Tasks;
using Tres.Products.Models;

namespace Tres.Products.Services
{
    public interface IProductService 
    {
        Task<List<Product>> GetProductsAsync(int ModuleId);

        Task<Product> GetProductAsync(int ProductId);

        Task<Product> AddProductAsync(Product Product);

        Task<Product> UpdateProductAsync(Product Product);

        Task DeleteProductAsync(int ProductId);
    }
}
