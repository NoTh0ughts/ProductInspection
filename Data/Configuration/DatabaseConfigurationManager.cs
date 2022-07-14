
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Configuration
{
    public static class DatabaseConfigurationManager
    {
        private static string _connectionString;

        public static string ConnectionString
        {
            get 
            {
                if (string.IsNullOrEmpty(_connectionString))
                    throw new InvalidOperationException("Connection string is null, call DatabaseConfigurationManager.UseDatabase");
                return _connectionString;
            }
            set { _connectionString = value; }
        }

        public static void UseDatabase(this ServiceCollection services, ConfigurationModel configuration)
        {
            SqlConnectionStringBuilder conStrBuilder = new SqlConnectionStringBuilder();

            conStrBuilder["Server"] = configuration?.Server;
            conStrBuilder["User id"] = configuration?.Username;
            conStrBuilder["Password"] = configuration?.Password;
            conStrBuilder["Initial Catalog"] = configuration?.InitialCatalog;
            conStrBuilder["Trusted_Connection"] = configuration?.TrustedConnection;

            ConnectionString = conStrBuilder.ToString();
        }
    }
}
