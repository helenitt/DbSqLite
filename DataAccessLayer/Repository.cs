using System;
using System.Collections.Generic;
using System.Linq;
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

        public int SaveUser(UserDetailsEntity userDetails)
        {
            var sql = @"INSERT INTO UserDetails (name, email, isStudent, hasBusinessBackground, hasTechnicalBackground, yearsExperience) " +
                               "VALUES (@Name, @Email, @IsStudent, @HasBusinessBackground, @HasTechnicalBackground,@YearsExperience); " +
                               "SELECT last_insert_rowid();";
            var userIdReturned = _dbConnect.Query<int>(sql, userDetails).First();
            return userIdReturned;
        }
        
        public void SaveUserResponseOptions(OptionEntity option, int userId)
        {
            var sql = @"INSERT INTO UserResponseOptions (userId, optionId) " +
                      " VALUES (@userId, (SELECT optionId FROM Options WHERE optionText = @OptionText AND questionId = @QuestionId))";
            _dbConnect.Execute(sql, new { userId, option.OptionText, option.QuestionId });
        }

        public IEnumerable<UserDetailsEntity> GetUserDetails()
        {
            const string sql = "SELECT * FROM UserDetails";
            var allUsersDetails = _dbConnect.Query<UserDetailsEntity>(sql);
            return allUsersDetails;
        }
    }
}
