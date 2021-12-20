using System;
using System.Collections.Generic;

namespace WebShop.Domain.Models
{
    public partial class Product
    {
        public long ProductId { get; set; }
        public long? ProductTypeId { get; set; }
        public string? Description { get; set; }
        public string? Code { get; set; }
        public decimal? Price { get; set; }
        public int? NoOfItems { get; set; }
        public long? ManufacturerId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsActive { get; set; }

        public virtual Manufacturer? Manufacturer { get; set; }
        public virtual ProductType? ProductType { get; set; }
    }
}
