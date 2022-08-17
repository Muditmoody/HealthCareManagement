using System.Linq;
using System.Data.SqlClient;
using HealthCareManagement.Models;

namespace HealthCareManagement.BusinessLogic
{
    public class DatabaseProvider
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        public DatabaseProvider(IConfiguration configuration, ILogger<DatabaseProvider> logger)
        {
            _logger = logger;
            _configuration = configuration;
            this.TestConnection();
        }

        public bool TestConnection()
        {
            var success = true;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("healthcaremngt")))
                {
                    sqlConnection.Open();
                    var sql = "Select 1";
                    SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
                    var reader = sqlCommand.ExecuteReader();

                    if (reader.HasRows)
                    {
                        _logger.LogInformation("Connection tested");
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                success = false;
            }
            return success;
        }

        private SqlConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("healthcaremngt"));
        }

        public List<T> ExecuteQuery<T>(string strQuery, Func<SqlDataReader, T> mapper)
        {
            var retObj = new List<T>();
            using (var conn = this.CreateConnection())
            {
                conn.Open();
                using (var command = new SqlCommand(strQuery, conn))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                            while (reader.Read())
                            {
                                retObj.Add(mapper(reader));
                            }
                    }
                }
            }
            return retObj;
        }
    }

}
