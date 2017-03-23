using System.Data.SQLite;

namespace DbSQLite.Db
{
    class DbConnection
    {
        private static SQLiteConnection _dbConnection;

        public static void ConnectDb()
        {
            _dbConnection = new SQLiteConnection("Data Source=TestSystem.sqlite;Version=3;");
            _dbConnection.Open();
        }

        public static void ConnectNonQuery(string sql)
        {
            ConnectDb();
            var command = new SQLiteCommand(sql, _dbConnection);
            command.ExecuteNonQuery();
            _dbConnection.Close();
        }

        public static SQLiteDataReader ConnectDatareader(string sql)
        {
            ConnectDb();
            var command = new SQLiteCommand(sql, _dbConnection);
            var dataReader = command.ExecuteReader();
            return dataReader;
        }

        public static void ConnectClose()
        {
            _dbConnection.Close();
        }
    }
}
