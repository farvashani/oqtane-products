using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using Tres.Products.Models;
using Tres.Products.Repository;

namespace Tres.Products.Controllers
{
    [Route("{site}/api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _Products;
        private readonly ILogManager _logger;

        public ProductController(IProductRepository Products, ILogManager logger)
        {
            _Products = Products;
            _logger = logger;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Roles = Constants.RegisteredRole)]
        public IEnumerable<Product> Get(string moduleid)
        {
            return _Products.GetProducts(int.Parse(moduleid));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Roles = Constants.RegisteredRole)]
        public Product Get(int id)
        {
            return _Products.GetProduct(id);
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Roles = Constants.AdminRole)]
        public Product Post([FromBody] Product Product)
        {
            if (ModelState.IsValid)
            {
                Product = _Products.AddProduct(Product);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Product Added {Product}", Product);
            }
            return Product;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Roles = Constants.AdminRole)]
        public Product Put(int id, [FromBody] Product Product)
        {
            if (ModelState.IsValid)
            {
                Product = _Products.UpdateProduct(Product);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Product Updated {Product}", Product);
            }
            return Product;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = Constants.AdminRole)]
        public void Delete(int id)
        {
            _Products.DeleteProduct(id);
            _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Product Deleted {ProductId}", id);
        }
    }
}
