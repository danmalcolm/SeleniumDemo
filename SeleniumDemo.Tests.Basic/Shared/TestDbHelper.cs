using System.Configuration;
using System.Data.SqlClient;

namespace SeleniumDemo.Tests.Basic.Shared
{
    public class TestDbHelper
    {
        private const string ResetSql = @"
delete from webpages_Membership
delete from UserProfile";

        public static void ResetData()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["WebAppDefaultConnection"].ConnectionString;
            using(var connection = new SqlConnection(connectionString))
            using(var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = ResetSql;
                command.ExecuteNonQuery();
            }
        }
    }
}