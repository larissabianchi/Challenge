using Challenge.Models;

namespace Challenge.Interface
{
    public interface IUserAddressRepository
    {
        IEnumerable<UserAddress> GetAll();

        UserAddress Add(UserAddress item);
    }
}
