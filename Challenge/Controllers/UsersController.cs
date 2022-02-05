using Challenge.Interface;
using Challenge.Models;
using Challenge.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Challenge.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        static readonly IUserRepository repository = new UserRepository();

        [Route("/users")]
        public IEnumerable<User> GetAllUsers()
        {
            return repository.GetAll();
        }

        [Route("/users/id/{id}")]
        public User GetUserById(int id)
        {
            User item = repository.Get(id);

            if(item == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return item;
        }

        [Route("/users/name/{name}")]
        public IEnumerable<User> GetUserByName(string name)
        {
            return repository.GetAll().Where(
                user => string.Equals(user.Name, name, StringComparison.OrdinalIgnoreCase)
            );
        }

        [Route("/users/username/{username}")]
        public IEnumerable<User> GetUserByUsername(string username)
        {
            return repository.GetAll().Where(
                user => string.Equals(user.Username, username, StringComparison.OrdinalIgnoreCase)    
            );
        }

        [Route("/users/email/{email}")]
        public IEnumerable<User> GetUserByEmail(string email)
        {
            return repository.GetAll().Where(
                user => string.Equals(user.Email, email, StringComparison.OrdinalIgnoreCase)
            );
        }
    }
}
