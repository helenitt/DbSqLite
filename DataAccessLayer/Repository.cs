using System.Collections.Generic;
using Entities;
using Models;

namespace DataAccessLayer
{
    public class Repository : IRepository
    {
        readonly DbConnect _dbConnect;

        public Repository()
        {
            _dbConnect = new DbConnect();
        }

        public void SaveUser(UserDetailsEntity userDetails)
        {
            var sql = "INSERT INTO UserDetails (name, email, isStudent, hasBusinessBackground, hasTechnicalBackground, yearsExperience) " +
                      "VALUES ('" + userDetails.Name + "', '" + userDetails.Email + "', '" + userDetails.IsStudent +
                      "', '" + userDetails.HasBusinessBackground + "', '" + userDetails.HasTechnicalBackground +
                       "', '" + userDetails.YearsExperience + "')";
            _dbConnect.Execute(sql);
        }

        // Look up ref Table Questions
        // Save to Options
        // Save to UserResponseOptions

        public void SaveUserResponseOption(UserDetailsEntity userDetails)
        {
            // Look up ref Table Questions
            var questNumber = CheckQuestionNumber(userDetails.Answers.QuestionNumber);
            // Save to Options
            var id = SaveOptions(userDetails, questNumber);
            // Save to UserResponseOptions ---- DON'T THINK USERID HAS BEEN BROUGHT BACK YET
            var sql = "INSERT INTO UserResponseOptions (userId, OptionId) VALUES (" + userDetails.UserDetailsId + ", " + id + ")";
        }

        // HERE
        public int SaveOptions(UserDetailsEntity userDetails, int questNumber)
        {
            var sql = "INSERT INTO Options (optionText, questionId) VALUES ('" + userDetails.Answers.Option + "', " + questNumber + ")";
            Execute(sql);
            sql = "SELECT MAX(optionId) FROM Options";
            return Query<TEntity>(sql);
        }

        //HERE
        public int CheckQuestionNumber(int questNumber)
        {
            var sql = "SELECT questionNumber FROM Questions WHERE " + questNumber + " = questionNumber";
            return Query<TEntity>(sql);
        }

        public IEnumerable<UserDetailsEntity> GetUserDetails()
        {
            const string sql = "SELECT * FROM UserDetails";
            var allUsersDetails = _dbConnect.Query<UserDetailsEntity>(sql);
            return allUsersDetails;
        }
    }
}
