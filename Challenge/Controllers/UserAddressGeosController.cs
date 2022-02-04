using Challenge.Interface;
using Challenge.Models;
using Challenge.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    [Route("UserAddressGeosController")]
    [ApiController]
    public class UserAddressGeosController : ControllerBase
    {
        static readonly IUserAddressGeoRepository repository = new UserAddressGeoRepository();

        public IEnumerable<UserAddressGeo> GetAllUserCompanies()
        {
            return repository.GetAll();
        }
    }
}
