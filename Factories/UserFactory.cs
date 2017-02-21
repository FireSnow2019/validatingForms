using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;

using mvcnewdojo.Models;

namespace DapperApp.Factory
{
    public class UserFactory : IFactory<User>
    {
        private string connectionString;
        
        public UserFactory()
        {
            string host = "localhost";
            string port = "3306";
            string usr = "root";
            string pwd = "root";
            string db = "CoderSchema";

            connectionString = $"server={host};userid={usr};password={pwd};port={port};database={db};SslMode=None";
        }
        internal IDbConnection Connection
        {
            get{
                return new MySqlConnection(connectionString);
            }
        }

        public void Add(User item)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string query = "INSERT INTO users(FirstName,LastName, UserName,Password,CreatedDate,LogedOutDate)VALUES(@firstname,@lastname,@UserName,@Password,NOW(),NOW())";
                dbConnection.Open();
                dbConnection.Execute(query,item);
            }
        }

        public IEnumerable<User> FindAll()
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM Users");
            }
        }

        public User FindByID(int id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<User>("SELECT * FROM Users WHERE idUsers=@id",new {Id = id}).FirstOrDefault();
            }
        }

    }
}