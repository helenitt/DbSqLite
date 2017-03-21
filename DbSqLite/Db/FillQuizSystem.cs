namespace DbSQLite.Db
{
    class FillQuizSystem
    {
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
