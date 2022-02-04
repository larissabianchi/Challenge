using Challenge.Interface;
using Challenge.Models;
using Newtonsoft.Json;
using System.Net;

namespace Challenge.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>();

        public UserRepository ()
        {
            var json = new WebClient().DownloadString("https://jsonplaceholder.typicode.com/users");

            var user = JsonConvert.DeserializeObject<List<User>>(json);
        }

        public User Add(User item)
        {
            if(item == null)
            {
                throw new NotImplementedException();
            }

            users.Add(item);

            return item;            
        }

        public User Get(int id)
        {
            return users.Find(user => user.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }
    }
}
