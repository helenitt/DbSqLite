using System.Data.SQLite;

namespace DbSqLite.Db
{
    class CreateQuizSystem
    {
        
        public static void CreateQuizSystemDb()
        {
            SQLiteConnection.CreateFile("QuizSystem.sqlite"); 
            
            var sql = "create table questions (questionNumber int, questionText varchar(50))";
            DbConnection.ConnectNonQuery(sql);

            sql = "insert into questions (questionNumber, questionText) values (1, 'What do we do?')";
            DbConnection.ConnectNonQuery(sql);

            sql = "insert into questions (questionNumber, questionText) values (2, 'Are you interested in a career with Aspen grove?')";
            DbConnection.ConnectNonQuery(sql);

            sql = "insert into questions (questionNumber, questionText) values (3, 'What area are you interested in?')";
            DbConnection.ConnectNonQuery(sql);
        }
    }
}
