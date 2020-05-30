using Oqtane.Models;
using Oqtane.Modules;

namespace Tres.Products
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Product",
            Description = "Product",
            Version = "1.0.0",
            ServerManagerType = "Tres.Products.Manager.ProductManager, Tres.Products.Server.Oqtane",
            ReleaseVersions = "1.0.0"
        };
    }
}
