using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using Tres.Products.Models;

namespace Tres.Products.Repository
{
    public class ProductRepository : IProductRepository, IService
    {
        private readonly ProductContext _db;

        public ProductRepository(ProductContext context)
        {
            _db = context;
        }

        public IEnumerable<Product> GetProducts(int ModuleId)
        {
            return _db.Product.Where(item => item.ModuleId == ModuleId);
        }

        public Product GetProduct(int ProductId)
        {
            return _db.Product.Find(ProductId);
        }

        public Product AddProduct(Product Product)
        {
            _db.Product.Add(Product);
            _db.SaveChanges();
            return Product;
        }

        public Product UpdateProduct(Product Product)
        {
            _db.Entry(Product).State = EntityState.Modified;
            _db.SaveChanges();
            return Product;
        }

        public void DeleteProduct(int ProductId)
        {
            Product Product = _db.Product.Find(ProductId);
            _db.Product.Remove(Product);
            _db.SaveChanges();
        }
    }
}
