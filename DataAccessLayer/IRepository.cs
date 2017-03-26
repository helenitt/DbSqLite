using Entities;

namespace DataAccessLayer
{
    public interface IRepository
    {
        void SaveUser(UserResponseEntity userResponse);
    }
}
