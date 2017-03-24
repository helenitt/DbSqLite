using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccessLayer
{
    public class Repository : IRepository
    {
        public void Save(UserResponseEntity userResponse)
        {
            var sql = "INSERT INTO UserResponse (name, email) VALUES ('" + userResponse.Name + "', '" + userResponse.Email + "')";
            DbConnection.ConnectNonQuery(sql);
        }
    }
}
