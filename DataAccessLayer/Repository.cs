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
            const string sql = @"INSERT INTO UserDetails (name, email, isStudent, hasBusinessBackground, hasTechnicalBackground, yearsExperience)" +
                               "VALUES (@Name, @Email, @IsStudent, @HasBusinessBackground, @HasTechnicalBackground,@YearsExperience)";
            _dbConnect.Execute(sql, new { userDetails.Name, userDetails.Email, userDetails.IsStudent, userDetails.HasBusinessBackground, userDetails.HasTechnicalBackground, userDetails.YearsExperience });
        }

        public void SaveUserResponseOptions(UserResponseOptionEntity userDetails)
        {
            var sql = "INSERT INTO UserResponseOptions (userId, optionId)" +
                      "VALUES (" + userDetails.UserDetailsId + ", '" + userDetails.OptionId + "')";
            _dbConnect.Execute(sql);
        }

        public IEnumerable<UserDetailsEntity> GetUserDetails()
        {
            const string sql = "SELECT * FROM UserDetails";
            var allUsersDetails = _dbConnect.Query<UserDetailsEntity>(sql);
            return allUsersDetails;
        }
    }
}
