using System;

namespace Db.Db
{
    class FillQuizSystem
    {
        public void FillQuestionTable()
        {
            var sql = "insert into questions (questionNumber, questionText) values (1, 'What do we do?')";
            DbConnection.ConnectNonQuery(sql);

            sql = "insert into questions (questionNumber, questionText) values (2, 'Are you interested in a career with Aspen grove?')";
            DbConnection.ConnectNonQuery(sql);

            sql = "insert into questions (questionNumber, questionText) values (3, 'What area are you interested in?')";
            DbConnection.ConnectNonQuery(sql);
        }
    }
}
