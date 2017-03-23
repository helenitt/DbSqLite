using System.Data.SQLite;

namespace DbSQLite.Db
{
    class CreateQuizSystem
    {
        public static void CreateQuizSystemDb()
        {
            SQLiteConnection.CreateFile("QuizSystem.sqlite");

            FillQuizSystem.CreateUserResponseTable();
            FillQuizSystem.CreateResponseOptionTable();
        }
    }
}
