using Challenge.Interface;
using Challenge.Models;

namespace Challenge.Repositories
{
    public class UserAddressRepository : IUserAddressRepository
    {
        private List<UserAddress> userAddresses = new List<UserAddress>();

        public UserAddress Add(UserAddress item)
        {
            if(item == null)
            {
                throw new NotImplementedException();
            }

            userAddresses.Add(item);

            return item;
        }
    }
}
