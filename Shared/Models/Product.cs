using System;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace Tres.Products.Models
{
    [Table("TresProduct")]
    public class Product : IAuditable
    {
        public int ProductId { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string DetailDescription { get; set; }
        public string Url { get; set; }


        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
