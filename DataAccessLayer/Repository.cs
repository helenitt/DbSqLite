using System;
using System.Collections.Generic;
using Entities;
using System.Data.SQLite;
using System.IO;

namespace DataAccessLayer
{
    public class Repository : IRepository
    {
        DbConnect dbConnect;

        public Repository()
        {
            dbConnect = new DbConnect();
            
        }

        public void SaveUser(UserDetailsEntity userDetails)
        {
            var sql = "INSERT INTO UserDetails (name, email) VALUES ('" + userDetails.Name + "', '" + userDetails.Email + "')";
            dbConnect.Execute(sql);
        }

        public IEnumerable<UserDetailsEntity> GetUserDetails()
        {
            var sql = "SELECT * FROM UserDetails";
            var allUsersDetails = dbConnect.Query<UserDetailsEntity>(sql);
            return allUsersDetails;
        }
    }
}
