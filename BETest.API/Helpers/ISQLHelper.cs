using System.Data.SqlClient;

namespace BETest.API.Helpers
{
    public interface ISQLHelper
    {
        SqlConnection GetSQLConnection();
    }
}
