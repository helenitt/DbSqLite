using System.Data.SqlClient;
using System.Data.SQLite;

namespace DataAccessLayer
{
    class DbConnection
    {
        public static void ConnectNonQuery(string sql)
        {
            using (var connection = new SQLiteConnection("Data Source=TestSystem.sqlite;Version=3;"))
            {
                var command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }

        //public static SQLiteDataReader ConnectDatareader(string sql)
        //{
        //    ConnectDb();
        //    var command = new SQLiteCommand(sql, _dbConnection);
        //    var dataReader = command.ExecuteReader();
        //    return dataReader;
        //}
    }
}
