using System.Data.SQLite;

namespace DataAccessLayer
{
    class DbConnection
    {
        public static void ConnectNonQuery(string sql)
        {
            using (var connection = new SQLiteConnection("Data Source=QuizSystem.sqlite;Version=3;"))
            {
                var command = new SQLiteCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }

        public static SQLiteDataReader ConnectDatareader(string sql)
        {
            using (var connection = new SQLiteConnection("Data Source=QuizSystem.sqlite;Version=3;"))
            {
                var command = new SQLiteCommand(sql, connection);
                var dataReader = command.ExecuteReader();
                return dataReader;
            }
        }
    }
}
