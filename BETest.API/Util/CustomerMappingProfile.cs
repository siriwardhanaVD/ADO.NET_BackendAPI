using AutoMapper;
using BETest.API.Application.UseCases.Orders;
using BETest.API.Entities;
using System;
using System.Data;

namespace BETest.API.Util
{
    public class CustomerMappingProfile:Profile
    {
        public CustomerMappingProfile()
        {
            /*
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
             */

            IMappingExpression<DataRow, OrdersResponse> getOrderDetails;
            getOrderDetails=CreateMap<DataRow, OrdersResponse>();
            getOrderDetails.ForMember(d => d.OrderId, o => o.MapFrom(s => s["OrderId"]));
            getOrderDetails.ForMember(d => d.OrderStatus, o => o.MapFrom(s => (s["OrderStatus"] != DBNull.Value) ? s["OrderStatus"] : ""));
            getOrderDetails.ForMember(d => d.OrderType, o => o.MapFrom(s => (s["OrderType"] != DBNull.Value) ? s["OrderType"] : ""));
            getOrderDetails.ForMember(d => d.OrderedOn, o => o.MapFrom(s => (s["OrderedOn"] != DBNull.Value) ? s["OrderedOn"] : ""));
            getOrderDetails.ForMember(d => d.ShippedOn, o => o.MapFrom(s => (s["ShippedOn"] != DBNull.Value) ? s["ShippedOn"] : ""));
            getOrderDetails.ForMember(d => d.OrderIsActive, o => o.MapFrom(s => s["OrderIsActive"]));
            getOrderDetails.ForMember(d => d.UserId, o => o.MapFrom(s => s["UserId"]));
            getOrderDetails.ForMember(d => d.ProductId, o => o.MapFrom(s => s["ProductId"]));
            getOrderDetails.ForMember(d => d.ProductName, o => o.MapFrom(s => (s["ProductName"] != DBNull.Value) ? s["ProductName"] : ""));
            getOrderDetails.ForMember(d => d.UnitPrice, o => o.MapFrom(s => (s["UnitPrice"] != DBNull.Value) ? s["UnitPrice"] : ""));
            getOrderDetails.ForMember(d => d.ProductCreatedOn, o => o.MapFrom(s => (s["ProductCreatedOn"] != DBNull.Value) ? s["ProductCreatedOn"] : ""));
            getOrderDetails.ForMember(d => d.ProductAvailability, o => o.MapFrom(s => (s["ProductAvailability"] != DBNull.Value) ? s["ProductAvailability"] : ""));
            getOrderDetails.ForMember(d => d.SupplerId, o => o.MapFrom(s => s["SupplerId"]));
            getOrderDetails.ForMember(d => d.SupplierName, o => o.MapFrom(s => (s["SupplierName"] != DBNull.Value) ? s["SupplierName"] : ""));
            getOrderDetails.ForMember(d => d.SupplierCreatedOn, o => o.MapFrom(s => (s["SupplierCreatedOn"] != DBNull.Value) ? s["SupplierCreatedOn"] : ""));
            getOrderDetails.ForMember(d => d.SupplierIsActive, o => o.MapFrom(s => (s["SupplierIsActive"] != DBNull.Value) ? s["SupplierIsActive"] : ""));
            
        }
    }
}
