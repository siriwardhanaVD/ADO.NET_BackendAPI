using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BETest.API.Entities
{
    public partial class Supplier
    {
        public Supplier()
        {
            Product = new HashSet<Product>();
        }

        public Guid SupplerId { get; set; }
        public string SupplierName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
