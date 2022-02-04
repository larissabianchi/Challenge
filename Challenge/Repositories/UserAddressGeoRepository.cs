using Challenge.Interface;
using Challenge.Models;

namespace Challenge.Repositories
{
    public class UserAddressGeoRepository : IUserAddressGeoRepository
    {
        private List<UserAddressGeo> userAddressGeos = new List<UserAddressGeo>();

        public UserAddressGeo Add(UserAddressGeo item)
        {
            if(item == null)
            {
                throw new NotImplementedException();
            }

            userAddressGeos.Add(item);

            return item;
        }

        public IEnumerable<UserAddressGeo> GetAll()
        {
            return userAddressGeos;
        }
    }
}
