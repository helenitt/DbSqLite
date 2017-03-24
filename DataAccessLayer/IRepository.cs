using Entities;

namespace DataAccessLayer
{
    public interface IRepository
    {
        void Save(UserResponseEntity userResponse);
    }
}
