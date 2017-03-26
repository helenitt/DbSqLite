using Entities;
using System.Data.SQLite;

namespace DataAccessLayer
{
    public class Repository : IRepository
    {
        public void CreateUserDetailsTable()
        {
            var sql = "CREATE TABLE UserDetails (userId INTEGER PRIMARY KEY AUTOINCREMENT, name varchar(30), email varchar(50))";
            DbConnection.ConnectNonQuery(sql);
        }

        public void SaveUser(UserResponseEntity userResponse)
        {
            var sql = "INSERT INTO UserDetails (name, email) VALUES ('" + userResponse.Name + "', '" + userResponse.Email + "')";
            DbConnection.ConnectNonQuery(sql);
        }

        public SQLiteDataReader SelectUsers()
        {
            var sql = "SELECT * FROM UserDetails";
            return DbConnection.ConnectDatareader(sql);
        }
    }
}
