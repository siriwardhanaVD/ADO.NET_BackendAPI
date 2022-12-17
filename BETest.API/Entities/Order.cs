using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BETest.API.Entities
{
    public partial class Order
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int? OrderStatus { get; set; }
        public int? OrderType { get; set; }
        public Guid OrderBy { get; set; }
        public DateTime? OrderedOn { get; set; }
        public DateTime? ShippedOn { get; set; }
        public bool IsActive { get; set; }

        public virtual Customer OrderByNavigation { get; set; }
        public virtual Product Product { get; set; }
    }
}
