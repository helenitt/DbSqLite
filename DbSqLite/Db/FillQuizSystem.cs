namespace DbSQLite.Db
{
    class FillQuizSystem
    {
        public static void CreateQuestionTable()
        {
            var sql = "create table Questions (questionNumber int, questionText varchar(50))";
            DbConnection.ConnectNonQuery(sql);
        }

        public static void CreateResponseTable()
        {
            var sql = "create table Response (userId int, name varchar(30), email varchar(40))";
            DbConnection.ConnectNonQuery(sql);
        } 

        public static void CreateResponseOptionTable()
        {
            var sql = "create table ResponseOption (userId int, questionNumber int, optionSelected varchar(50))";
            DbConnection.ConnectNonQuery(sql);
        }

        public static void FillQuestionTable()
        {
            var sql = "insert into questions (questionNumber, questionText) values (1, 'What do we do?')";
            DbConnection.ConnectNonQuery(sql);

            sql = "insert into questions (questionNumber, questionText) values (2, 'Are you interested in a career with Aspen grove?')";
            DbConnection.ConnectNonQuery(sql);

            sql = "insert into questions (questionNumber, questionText) values (3, 'What area are you interested in?')";
            DbConnection.ConnectNonQuery(sql);
        }

        public static void InsertToResponseOption(int id, int number, string response)
        {
            var sql = "insert into ResponseOption (userId, questionNumber, optionSelected) values (" + id + ", " + number + ", '" + response + "')";
            DbConnection.ConnectNonQuery(sql);
        }

        public static void SelectResponses(int id)
        {
            var sql = "select * from ResponseOption where UserId = " + id;
            DbConnection.ConnectDatareader(sql);
        }
    }
}
