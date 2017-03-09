using System;
using System.Data.SQLite;

namespace DbSqLite.Db
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

        public static void ConnectDatareader(string sql)
        {
            ConnectDb();
            var command = new SQLiteCommand(sql, _dbConnection);
            SQLiteDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
                Console.WriteLine("Number " + dataReader["questionNumber"] + "\tText " + dataReader["questionText"]);
        }
    }
}
