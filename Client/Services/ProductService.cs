using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using Tres.Products.Models;

namespace Tres.Products.Services
{
    public class ProductService : ServiceBase, IProductService, IService
    {
        private readonly SiteState _siteState;

        public ProductService(HttpClient http, SiteState siteState) : base(http)
        {
            _siteState = siteState;
        }

         private string Apiurl=> CreateApiUrl(_siteState.Alias, "Product");

        public async Task<List<Product>> GetProductsAsync(int ModuleId)
        {
            List<Product> Products = await GetJsonAsync<List<Product>>($"{Apiurl}?moduleid={ModuleId}");
            return Products.OrderBy(item => item.Name).ToList();
        }

        public async Task<Product> GetProductAsync(int ProductId)
        {
            return await GetJsonAsync<Product>($"{Apiurl}/{ProductId}");
        }

        public async Task<Product> AddProductAsync(Product Product)
        {
            return await PostJsonAsync<Product>($"{Apiurl}?entityid={Product.ModuleId}", Product);
        }

        public async Task<Product> UpdateProductAsync(Product Product)
        {
            return await PutJsonAsync<Product>($"{Apiurl}/{Product.ProductId}?entityid={Product.ModuleId}", Product);
        }

        public async Task DeleteProductAsync(int ProductId)
        {
            await DeleteAsync($"{Apiurl}/{ProductId}");
        }
    }
}
