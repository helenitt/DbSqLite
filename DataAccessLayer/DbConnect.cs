using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using Dapper;

namespace DataAccessLayer
{
    public class DbConnect
    {
        private string FilePath;
        private string ConnectionString; 
        
        public DbConnect()
        {
            var destinationDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            FilePath = Path.Combine(destinationDirectory, "QuizSystem.sqlite");
            ConnectionString = string.Format("Data Source={0};Version=3;", FilePath);
            CreateQuizSystemDb();
        }

        public void CreateQuizSystemDb()
        {
            
            if (!File.Exists(FilePath))
            {
                SQLiteConnection.CreateFile(FilePath);
                CreateUserDetailsTable();
            }
        }

        private void CreateUserDetailsTable()
        {
            const string sql = "CREATE TABLE UserDetails (userId INTEGER PRIMARY KEY AUTOINCREMENT, name varchar(30), email varchar(50))";
            Execute(sql);
        }

        public void Execute(string sql)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                 connection.Execute(sql);
            }
        }

        public IEnumerable<TEntity> Query<TEntity>(string sql)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.Query<TEntity>(sql);
            }
        }
    }
}
