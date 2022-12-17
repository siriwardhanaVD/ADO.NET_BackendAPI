using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BETest.API.Entities
{
    public partial class Product
    {
        public Product()
        {
            Order = new HashSet<Order>();
        }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public Guid SupplierId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool IsActive { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
