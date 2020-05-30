using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Repository;
using Tres.Products.Models;
using Tres.Products.Repository;

namespace Tres.Products.Manager
{
    public class ProductManager : IInstallable, IPortable
    {
        private IProductRepository _Products;
        private ISqlRepository _sql;

        public ProductManager(IProductRepository Products, ISqlRepository sql)
        {
            _Products = Products;
            _sql = sql;
        }

        public bool Install(Tenant tenant, string version)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "Tres.Products." + version + ".sql");
        }

        public bool Uninstall(Tenant tenant)
        {
            return _sql.ExecuteScript(tenant, GetType().Assembly, "Tres.Products.Uninstall.sql");
        }

        public string ExportModule(Module module)
        {
            string content = "";
            List<Product> Products = _Products.GetProducts(module.ModuleId).ToList();
            if (Products != null)
            {
                content = JsonSerializer.Serialize(Products);
            }
            return content;
        }

        public void ImportModule(Module module, string content, string version)
        {
            List<Product> Products = null;
            if (!string.IsNullOrEmpty(content))
            {
                Products = JsonSerializer.Deserialize<List<Product>>(content);
            }
            if (Products != null)
            {
                foreach(Product Product in Products)
                {
                    Product _Product = new Product();
                    _Product.ModuleId = module.ModuleId;
                    _Product.Name = Product.Name;
                    _Products.AddProduct(_Product);
                }
            }
        }
    }
}