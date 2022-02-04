using Challenge.Interface;
using Challenge.Models;

namespace Challenge.Repositories
{
    public class UserCompanyRepository : IUserCompanyRepository
    {
        private List<UserCompany> userCompanies = new List<UserCompany>();

        public UserCompany Add(UserCompany item)
        {
            if(item == null)
            {
                throw new NotImplementedException();
            }

            userCompanies.Add(item);

            return item;
        }

        public IEnumerable<UserCompany> GetAll()
        {
            return userCompanies;
        }
    }
}
