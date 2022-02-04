using Challenge.Models;

namespace Challenge.Interface
{
    public interface IUserAddressGeoRepository
    {
        IEnumerable<UserAddressGeo> GetAll();

        UserAddressGeo Add(UserAddressGeo item);
    }
}
