using Microsoft.Data.SqlClient;
using Model.Exceptions;
using Newtonsoft.Json;
using System.Data;

namespace Sandbox.Database
{
    public class DatabaseConnection
    {
        private SqlConnectionSettings _connectionSettings;

        public DatabaseConnection()
        {
            // TODO 20241228 load environment from configuration settings
            _connectionSettings = LoadSqlConnectionSettings(Environment.Local);
        }

        public SqlConnectionSettings LoadSqlConnectionSettings(Environment environment)
        {
            string filename = $"database.{environment.ToString().ToLower()}.json";

            using (StreamReader r = new StreamReader(Path.Join("Environments", filename)))
            {
                string json = r.ReadToEnd();
                SqlConnectionSettings? sqlConnection = JsonConvert.DeserializeObject<SqlConnectionSettings>(json);

                if (sqlConnection == null)
                {
                    throw new Exception("Null Sql Connection Settings");
                }

                return sqlConnection;
            }
        }

        public IDbConnection CreateConnection()
        {
            try
            {
                return new SqlConnection(_connectionSettings.ConnectionString);
            }
            catch (Exception e)
            {
                throw new SqlConnectionException("failed to load configuration", e); 
            }
        }
    }
}
