using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Tres.Products.Models;

namespace Tres.Products.Repository
{
    public class ProductContext : DBContextBase, IService
    {
        public virtual DbSet<Product> Product { get; set; }

        public ProductContext(ITenantResolver tenantResolver, IHttpContextAccessor accessor) : base(tenantResolver, accessor)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
