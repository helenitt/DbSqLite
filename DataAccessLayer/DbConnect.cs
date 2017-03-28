using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using Dapper;

namespace DataAccessLayer
{
    public class DbConnect
    {
        private readonly string _filePath;
        private readonly string _connectionString; 
        
        public DbConnect()
        {
            var destinationDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _filePath = Path.Combine(destinationDirectory, "QuizSystem.sqlite");
            _connectionString = string.Format("Data Source={0};Version=3;", _filePath);
            CreateQuizSystemDb();
        }

        private void CreateQuizSystemDb()
        {
            if (File.Exists(_filePath)) return;
            SQLiteConnection.CreateFile( _filePath);
            CreateUserDetailsTable();
        }

        private void CreateUserDetailsTable()
        {
            const string sql = "CREATE TABLE UserDetails (" +
                               "  userId INTEGER PRIMARY KEY AUTOINCREMENT" +
                               ", name VARCHAR(30)" +
                               ", email VARCHAR(50)" +
                               ", isStudent INTEGER Default 0" +
                               ", hasBusinessBackground INTEGER Default 0" +
                               ", hasTechnicalBackground INTEGER Default 0" +
                               ", yearsExperience INTEGER)";
            Execute(sql);
        }

        public void Execute(string sql)
        {
            using (var connection = new SQLiteConnection( _connectionString))
            {
                 connection.Execute(sql);
            }
        }

        public IEnumerable<TEntity> Query<TEntity>(string sql)
        {
            using (var connection = new SQLiteConnection( _connectionString))
            {
                return connection.Query<TEntity>(sql);
            }
        }
    }
}
