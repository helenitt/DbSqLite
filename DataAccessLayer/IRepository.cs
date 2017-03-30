using System.Collections.Generic;
using Entities;

namespace DataAccessLayer
{
    public interface IRepository
    {
        int SaveUser(UserDetailsEntity userDetails);
        void SaveUserResponseOptions(OptionEntity optionEntity, int userId);
        IEnumerable<UserDetailsEntity> GetUserDetails();
    }
}
