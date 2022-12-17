using BETest.API.Entities;
using BETest.API.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
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
    public class CustomerController:ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISQLHelper _sqlHelper;

        public CustomerController(IConfiguration configuration,ISQLHelper sqlHelper)
        {
            _configuration = configuration;
            _sqlHelper = sqlHelper;
        }

        [HttpPost]
        public string InserCustomer(Customer customer)
        {
            var sqlConnection = _sqlHelper.GetSQLConnection();
            try
            {
                // define INSERT query with parameters
                string query = "INSERT INTO [dbo].[Customer] VALUES (@UserId, @Username, @Email, @FirstName, @Lastname, @CreatedOn, @IsActive)";
                Guid userId = Guid.NewGuid();
                DateTime localDate = DateTime.Now;
                using (SqlCommand cmd = new SqlCommand(query, sqlConnection))
                {
                    // define parameters and their values
                    cmd.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = userId;
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 30).Value = customer.Username;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 20).Value = customer.Email;
                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 20).Value = customer.FirstName;
                    cmd.Parameters.Add("@Lastname", SqlDbType.VarChar, 20).Value = customer.LastName;
                    cmd.Parameters.Add("@CreatedOn", SqlDbType.DateTime).Value = localDate;
                    cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = customer.IsActive;

                    // open connection, execute INSERT, close connection
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();

                }
                return userId + " Customer Created Success!";

            }
            catch (Exception)
            {
                return "Customer Created Failed";
            }

        }
        [HttpPost]
        [Route("UpdateCustomer")]
        public string UpdateCustomer(Customer customer)
        {
            Guid userId = Guid.Parse(customer.UserId.ToString());
            var sqlConnection = _sqlHelper.GetSQLConnection();
            try
            {
                SqlCommand sqlComm = new SqlCommand("UPDATE Customer " +
                    "SET Username ='" + customer.Username +
                    "', Email = '" + customer.Email + "'" +
                    ", FirstName='" + customer.FirstName + "'" +
                    ", LastName='" + customer.LastName + "'" +
                    ", CreatedOn='" + customer.CreatedOn + "'" +
                    ", IsActive = '" + customer.IsActive + "'" +
                    "WHERE UserId='" + userId + "'", sqlConnection);
                sqlConnection.Open();
                sqlComm.ExecuteNonQuery();
                return customer.UserId + " Updated Successfully!";
            }
            catch (Exception)
            {
                return "User update has failed";
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

        }
        [HttpDelete]
        public string DeleteCustomer(string UserId)
        {
            Guid userId = Guid.Parse(UserId);
            var sqlConnection = _sqlHelper.GetSQLConnection();
            try
            {
                SqlCommand sqlComm = new SqlCommand("Delete from Customer where UserId='" + userId + "'", sqlConnection);
                sqlConnection.Open();
                sqlComm.ExecuteNonQuery();
                return userId + " Deleted Successfully!";
            }
            catch (Exception)
            {
                return "User deletetion has failed";
            }
            finally 
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

        }        
        [HttpGet]
        public async Task<List<Customer>> GetCustomerDetails()
        {
            List<Customer> CustomerList = new List<Customer>();
            try
            {
                string query = "SELECT* FROM Customer";
                var sqlConnection = _sqlHelper.GetSQLConnection();
                SqlCommand sqlComm = new SqlCommand(query, _sqlHelper.GetSQLConnection());
                SqlDataAdapter da = new SqlDataAdapter(sqlComm);
                DataTable dt=new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                { 
                    Customer obj=new Customer();
                    obj.UserId = dt.Rows[i]["UserId"].GetType().GUID;
                    obj.Username = dt.Rows[i]["Username"].ToString();
                    obj.Email = dt.Rows[i]["Email"].ToString();
                    obj.FirstName = dt.Rows[i]["FirstName"].ToString();
                    obj.LastName = dt.Rows[i]["LastName"].ToString();
                    obj.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);
                    obj.IsActive = Convert.ToBoolean(dt.Rows[i]["IsActive"]);
                    CustomerList.Add(obj);
                }
                return await Task.FromResult(CustomerList);
            }
            catch (Exception)
            {
                return (List<Customer>)Enumerable.Empty<Customer>();
            }

        }
        
        
    }
}
