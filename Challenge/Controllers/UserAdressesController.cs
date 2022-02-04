using Challenge.Interface;
using Challenge.Models;
using Challenge.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    [Route("UserAdressesController")]
    [ApiController]
    public class UserAdressesController : ControllerBase
    {
        static readonly IUserAddressRepository repository = new UserAddressRepository();

        public IEnumerable<UserAddress> GetAllUserCompanies()
        {
            return repository.GetAll();
        }
    }
}
