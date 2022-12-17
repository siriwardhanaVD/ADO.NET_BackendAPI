using AutoMapper;
using BETest.API.Application.UseCases.Orders;
using BETest.API.Entities;
using BETest.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BETest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ISQLHelper _sqlHelper;
        private readonly IMapper _mapper;

        public OrderController(IConfiguration configuration, ISQLHelper sqlHelper,IMapper mapper)
        {
            _configuration = configuration;
            _sqlHelper = sqlHelper;
            _mapper= mapper;
        }

        [HttpGet]
        public async Task<List<OrdersResponse>> GetActiveOrdersByCustomers()
        {
            try
            {

                using (SqlCommand sqlComm = new SqlCommand("[dbo].[GetActiveOrders]", _sqlHelper.GetSQLConnection()))
                {
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = sqlComm;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    List<OrdersResponse> result = _mapper.Map<List<DataRow>, List<OrdersResponse>>(new List<DataRow>(dt.Rows.OfType<DataRow>()));
                    return await Task.FromResult(result);
                }
            }

            catch (Exception ex)
            {
                return (List<OrdersResponse>)Enumerable.Empty<Order>();
            }

        }



        [HttpPost]
        public string PlaceOrder(Order order)
        {
            var sqlConnection = _sqlHelper.GetSQLConnection();
            try
            {
                Guid orderId = Guid.NewGuid();
                Guid productId = Guid.Parse(order.ProductId.ToString());
                Guid orderBy = Guid.Parse(order.OrderBy.ToString());
                string query = "INSERT INTO [dbo].[Order] VALUES (@OrderId, @ProductId, @OrderStatus, @OrderType, @OrderBy, @OrderedOn,@ShippedOn, @IsActive)";
                
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    cmd.Parameters.Add("@OrderId", SqlDbType.UniqueIdentifier).Value = orderId;
                    cmd.Parameters.Add("@ProductId", SqlDbType.UniqueIdentifier).Value = productId;
                    cmd.Parameters.Add("@OrderStatus", SqlDbType.Int, 1).Value = order.OrderStatus;
                    cmd.Parameters.Add("@OrderType", SqlDbType.Int, 1).Value = order.OrderType;
                    cmd.Parameters.Add("@OrderBy", SqlDbType.UniqueIdentifier).Value = orderBy;
                    cmd.Parameters.Add("@OrderedOn", SqlDbType.DateTime).Value = order.OrderedOn;
                    cmd.Parameters.Add("@ShippedOn", SqlDbType.DateTime).Value = order.ShippedOn;
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = order.IsActive;

                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();

                }
                return orderId + " Placed Order Successfully!";
            }
            catch (Exception ex)
            {
                return "Order cannot be done!";
            }

        }
    }
}
