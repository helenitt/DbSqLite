using System.Collections.Generic;
using Entities;

namespace DataAccessLayer
{
    public interface IRepository
    {
        void SaveUser(UserDetailsEntity userDetails);
        void SaveUserResponseOptions(UserDetailsEntity userDetailsEntity);
        IEnumerable<UserDetailsEntity> GetUserDetails();
    }
}
