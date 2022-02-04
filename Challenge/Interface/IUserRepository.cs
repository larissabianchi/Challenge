using Challenge.Models;

namespace Challenge.Interface
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User Get(int id);

        User Add(User item);
    }
}
