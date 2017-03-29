using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using Dapper;
using Models;
using Newtonsoft.Json;

namespace DataAccessLayer
{
    public class DbConnect
    {
        private string _filePath;
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
            CreateQuestionsTable();
            CreateOptionsTable();
            CreateUserResponseOptions();
            PopulateStaticTables();
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

        private void CreateUserResponseOptions()
        {
            const string sql = "CREATE TABLE UserResponseOptions (" +
                               "  userResponseOptionId INTEGER PRIMARY KEY AUTOINCREMENT" +
                               ", userId INTEGER" +
                               ", optionId INTEGER" +
                               ", FOREIGN KEY(userId) REFERENCES UserDetails(userId)" +
                               ", FOREIGN KEY(optionId) REFERENCES Options(optionId))";
            Execute(sql);
        }
        // todo: Helen add the rest of the fields to these tables
        private void CreateOptionsTable()
        {
            const string sql = "CREATE TABLE Options (" +
                               "  optionId INTEGER PRIMARY KEY AUTOINCREMENT" +
                               ", optionText TEXT" +
                               ", questionId INTEGER" +
                               ", FOREIGN KEY(questionId) REFERENCES Questions(questionId))";
            Execute(sql);
        }

        private void CreateQuestionsTable()
        {
            const string sql = "CREATE TABLE Questions (questionId INTEGER PRIMARY KEY)";
            Execute(sql);
        }

        // Populate static tables, Options and Questions
        private void PopulateStaticTables()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(baseDirectory, "bin", "questions.json");
            var fileContents = File.ReadAllText(filePath);

            var questions = JsonConvert.DeserializeObject<LoadQuestionDto[]>(fileContents);
            foreach (var question in questions)
            {
                var sql = @"INSERT INTO Questions (questionId) VALUES (@QuestionNumber)";
                Execute(sql, new { question.QuestionNumber });

                foreach (var answer in question.Answers)
                {
                    sql = @"INSERT INTO Options (optionText, questionId) VALUES (@Option, @QuestionNumber)";
                    Execute(sql, new { answer.Option, question.QuestionNumber });
                }
            }
        }

        public void Execute(string sql, object parameters = null)
        {
            using (var connection = new SQLiteConnection( _connectionString))
            {
                if (parameters != null)
                {
                    connection.Execute(sql, parameters);
                }
                else
                {
                    connection.Execute(sql);
                }
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
