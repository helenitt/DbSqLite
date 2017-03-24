using System;
using System.Data.SQLite;
namespace DbSQLite.Db
{
     class FillQuizSystem
    {
        public static void CreateUserResponseTable()
        {
            const string sql = "create table UserResponse (userId INTEGER PRIMARY KEY AUTOINCREMENT, name varchar(30), email varchar(40))";
            DbConnection.ConnectNonQuery(sql);
        }

        public static void CreateResponseOptionTable()
        {
            const string sql = "create table ResponseOption (userId int, questionNumber int, optionSelected varchar(50))";
            DbConnection.ConnectNonQuery(sql);
        }

        public void InsertToUserResponse(string name, string email)
        {
            var sql = "insert into UserResponse (name, email) values (" + name + "', '" + email + "')";
            DbConnection.ConnectNonQuery(sql);
        }
        public static void InsertToResponseOption(int id, int number, string response)
        {
            var sql = "insert into ResponseOption (userId, questionNumber, optionSelected) values (" + id + ", " + number + ", '" + response + "')";
            DbConnection.ConnectNonQuery(sql);
        }

        

        public static SQLiteDataReader SelectUserDetails(int id)
        {
            var sql = "select * from UserResponse where userId = " + id;
            var dataReader = DbConnection.ConnectDatareader(sql);
            return dataReader;
        }

        public static SQLiteDataReader SelectResponses(int id)
        {
            var sql = "select * from ResponseOption where userId = " + id;
            var dataReader = DbConnection.ConnectDatareader(sql);
            return dataReader;
        }
    }
}
