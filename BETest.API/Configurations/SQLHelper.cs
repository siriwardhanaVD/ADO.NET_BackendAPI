using BETest.API.Helpers;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace BETest.API.Configurations
{
    public class SQLHelper : ISQLHelper
    {
        private readonly IOptions<BETestConfiguration> _options;

        public SQLHelper(IOptions<BETestConfiguration> options)
        {
            _options = options;
        }

        public SqlConnection GetSQLConnection()
        {
            string connetionString;
            SqlConnection connection;
            connetionString = _options.Value.SQLString;
            connection = new SqlConnection(connetionString);
            return connection;
        }

    }
}
