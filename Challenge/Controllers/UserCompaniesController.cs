using Challenge.Interface;
using Challenge.Models;
using Challenge.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    [Route("UserCompaniesController")]
    [ApiController]
    public class UserCompaniesController : ControllerBase
    {
        static readonly IUserCompanyRepository repository = new UserCompanyRepository();

        public IEnumerable<UserCompany> GetAllUserCompanies()
        {
            return repository.GetAll();
        }
    }
}
