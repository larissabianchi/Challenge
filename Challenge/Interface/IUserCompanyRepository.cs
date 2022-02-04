using Challenge.Models;

namespace Challenge.Interface
{
    public interface IUserCompanyRepository
    {
        IEnumerable<UserCompany> GetAll();

        UserCompany Add(UserCompany item);
    }
}
