using Challenge.Interface;
using Challenge.Models;
using Challenge.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
//using System.Web.Http;

namespace Challenge.Controllers
{
    [Route("UsersController")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        static readonly IUserRepository repository = new UserRepository();

        public IEnumerable<User> GetAllUsers()
        {
            return repository.GetAll();
        }

        public User GetUserById(int id)
        {
            User item = repository.Get(id);

            if(item == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return item;
        }

        public IEnumerable<User> GetUserByName(string name)
        {
            return repository.GetAll().Where(
                user => string.Equals(user.Name, name, StringComparison.OrdinalIgnoreCase)
            );
        }

        public IEnumerable<User> GetUserByUsername(string username)
        {
            return repository.GetAll().Where(
                user => string.Equals(user.Username, username, StringComparison.OrdinalIgnoreCase)    
            );
        }

        public IEnumerable<User> GetUserByEmail(string email)
        {
            return repository.GetAll().Where(
                user => string.Equals(user.Email, email, StringComparison.OrdinalIgnoreCase)
            );
        }
    }
}
