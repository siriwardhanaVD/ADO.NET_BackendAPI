using System;

namespace BETest.API.Application.UseCases.Orders
{
    public class OrdersResponse
    {
        //Order
        public Guid OrderId { get; set; }
        public int? OrderStatus { get; set; }
        public int? OrderType { get; set; }
        public DateTime? OrderedOn { get; set; }
        public DateTime? ShippedOn { get; set; }
        public bool OrderIsActive { get; set; }

        //Customer
        public Guid UserId { get; set; }

        //Product
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public DateTime? ProductCreatedOn { get; set; }
        public bool ProductAvailability { get; set; }

        //Supplier
        public Guid SupplerId { get; set; }
        public string SupplierName { get; set; }
        public DateTime? SupplierCreatedOn { get; set; }
        public bool SupplierIsActive { get; set; }
    }
}
