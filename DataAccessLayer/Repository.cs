using System.Collections.Generic;
using Entities;

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
            var sql = "INSERT INTO UserDetails (name, email, isStudent, hasBusinessBackground, hasTechnicalBackground, yearsExperience)" +
                      "VALUES ('" + userDetails.Name + "', '" + userDetails.Email + "', '" + userDetails.IsStudent +
                      "', '" + userDetails.HasBusinessBackground + "', '" + userDetails.HasTechnicalBackground +
                       "', '" + userDetails.YearsExperience + "')";
            _dbConnect.Execute(sql);
        }

        //public void SaveUserResponseOptions(UserResponseOptionEntity userOptions, UserDetailsEntity userDetails)
        //{
        //    var sql = "INSERT INTO UserResponseOptions (questionNumber, optionSelected, userId)" +
        //              "VALUES (" + userOptions.QuestionNumber + ", '" + userOptions.OptionSelected +
        //              ", '" + userDetails.UserDetailsId + "')";
        //    _dbConnect.Execute(sql);
        //}

        public IEnumerable<UserDetailsEntity> GetUserDetails()
        {
            const string sql = "SELECT * FROM UserDetails";
            var allUsersDetails = _dbConnect.Query<UserDetailsEntity>(sql);
            return allUsersDetails;
        }
    }
}
