using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;


namespace ConsoleApp2.Data
{
    public class DataContextDapper
    {
        private string _connectionString = "Server=(localdb)\\c#;Database=DotNetCourseDatabase;Trusted_Connection=true";

        public IEnumerable<T> LoadData<T>(string sqlCommand)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.Query<T>(sqlCommand);
        }

        public T LoadDataSingle<T>(string sqlCommand)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            return dbConnection.QuerySingle<T>(sqlCommand);
        }

        public bool Execute(string sqlCommand)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            int rowsAffected = dbConnection.Execute(sqlCommand);
            return rowsAffected > 0;
        }

        public int ExecuteWithCount(string sqlcommand)
        {
            IDbConnection dbConnection = new SqlConnection(_connectionString);
            int rowsAffected = dbConnection.Execute(sqlcommand);
            return rowsAffected;
        }
    }
}
