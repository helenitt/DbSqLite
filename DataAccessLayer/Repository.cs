using Entities;

namespace DataAccessLayer
{
    public class Repository : IRepository
    {
        public void CreateUserResponseTable()
        {
            var sql = "CREATE TABLE UserResponse (userId INTEGER PRIMARY KEY AUTOINCREMENT, name varchar(30), email varchar(50))";
            DbConnection.ConnectNonQuery(sql);
        }
        public void Save(UserResponseEntity userResponse)
        {
            var sql = "INSERT INTO UserResponse (name, email) VALUES ('" + userResponse.Name + "', '" + userResponse.Email + "')";
            DbConnection.ConnectNonQuery(sql);
        }
    }
}
