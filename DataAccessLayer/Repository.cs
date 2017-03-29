using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Entities;
using Models;

namespace DataAccessLayer
{
    public class Repository : IRepository
    {
        readonly DbConnect _dbConnect;
        readonly Answer _answer;

        public Repository()
        {
            _dbConnect = new DbConnect();
            _answer = new Answer();  // Don't know if this is right
        }

        public void SaveUser(UserDetailsEntity userDetails)
        {
            var sql = "INSERT INTO UserDetails (name, email, isStudent, hasBusinessBackground, hasTechnicalBackground, yearsExperience)" +
                      "VALUES ('" + userDetails.Name + "', '" + userDetails.Email + "', '" + userDetails.IsStudent +
                      "', '" + userDetails.HasBusinessBackground + "', '" + userDetails.HasTechnicalBackground +
                       "', '" + userDetails.YearsExperience + "')";
            _dbConnect.Execute(sql);
        }

        public void SaveUserResponseOptions(UserDetailsEntity userDetails)
        {
            
            // Save to Options
           // var id = SaveOptions(userDetails, questNumber);
            // Save to UserResponseOptions
            var sql = "INSERT INTO UserResponseOptions (userId, optionId)" +
                      "VALUES (" + userDetails.UserDetailsId + ", '" + _answer.Option + "')";
            _dbConnect.Execute(sql);
        }

        private UserDetailsEntity SaveOptions(UserDetailsEntity userDetails, int questNumber)
        {
            var sql = "INSERT INTO Options (optionText, questionId) VALUES ('" + _answer.Option + "', " + questNumber + ")";
            _dbConnect.Execute(sql);
            sql = "SELECT MAX(optionId) FROM Options";
            var userDetailsEntities = _dbConnect.Query<UserDetailsEntity>(sql);
            return new UserDetailsEntity();
        }

        public IEnumerable<UserDetailsEntity> GetUserDetails()
        {
            const string sql = "SELECT * FROM UserDetails";
            var allUsersDetails = _dbConnect.Query<UserDetailsEntity>(sql);
            return allUsersDetails;
        }
    }
}
