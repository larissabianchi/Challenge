using Challenge.Interface;
using Challenge.Models;
using Newtonsoft.Json;
using System.Net;

namespace Challenge.Repositories
{
    public class UserRepository : IUserRepository
    {
        private List<User> users = new List<User>();
        private List<UserAddress> userAddresses = new List<UserAddress>();
        private List<UserAddressGeo> userAddressGeos = new List<UserAddressGeo>();
        private List<UserCompany> userCompanies = new List<UserCompany>();

        public UserRepository ()
        {        
            using(WebClient webClient = new WebClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                var json = webClient.DownloadString("https://jsonplaceholder.typicode.com/users");
                dynamic users = JsonConvert.DeserializeObject(json);

                int id = 0;

                foreach (var user in users)
                {
                    id = user.id - 1;//a posição do array inicia em 0 e os registros em 1.

                    Add(new User
                    {
                        Id = user.id,
                        Name = user.name,
                        Username = user.username,
                        Email = user.email,

                        Address = userAddresses,

                        Phone = user.phone,
                        Website = user.website,

                        Company = userCompanies
                    }) ;                      
                }

                userAddressGeos.Add(new UserAddressGeo
                {
                    Lat = users[id].address.geo.lat,
                    Lng = users[id].address.geo.lng
                });

                userAddresses.Add(new UserAddress
                {
                    Street = users[id].address.street,
                    Suite = users[id].address.suite,
                    City = users[id].address.city,
                    Zipcode = users[id].address.zipcode,

                    Geo = userAddressGeos
                });

                userCompanies.Add(new UserCompany
                {
                    Name = users[id].company.name,
                    CatchPhrase = users[id].company.catchPhrase,
                    Bs = users[id].company.bs
                });
            }
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
