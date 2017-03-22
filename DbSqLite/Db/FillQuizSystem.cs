using System.Data.SQLite;

namespace DbSQLite.Db
{
    class FillQuizSystem
    {
        public static void CreateResponseTable()
        {
            var sql = "create table Response (userId int, name varchar(30), email varchar(40))";
            DbConnection.ConnectNonQuery(sql);
        } 

        public static void CreateResponseOptionTable()
        {
            var sql = "create table ResponseOption (userId int, questionNumber int, optionSelected varchar(50))";
            DbConnection.ConnectNonQuery(sql);
        }

        public static void InsertToUserResponse(int id, string name, string email)
        {
            var sql = "insert into UserResponse (userId, name, email) values (" + id + ", '" + name + "', '" + email + "')";
            DbConnection.ConnectNonQuery(sql);
        }

        public static void InsertToResponseOption(int id, int number, string response)
        {
            var sql = "insert into ResponseOption (userId, questionNumber, optionSelected) values (" + id + ", " + number + ", '" + response + "')";
            DbConnection.ConnectNonQuery(sql);
        }

        public static SQLiteDataReader SelectResponses(int id)
        {
            var sql = "select * from ResponseOption where UserId = " + id;
            return DbConnection.ConnectDataReader(sql);
        }
    }
}
