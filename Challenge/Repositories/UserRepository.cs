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
                dynamic user = JsonConvert.DeserializeObject(json);

                foreach (var result in user)
                {   
                    userAddressGeos.Add(new UserAddressGeo
                    {
                        Lat = result.address.geo.lat,
                        Lng = result.address.geo.lng
                    });

                    userAddresses.Add(new UserAddress
                    {
                        Street = result.address.street,
                        Suite = result.address.suite,
                        City = result.address.city,
                        Zipcode = result.address.zipcode,

                        Geo = userAddressGeos
                    });

                    userCompanies.Add(new UserCompany
                    {
                        Name = result.company.name,
                        CatchPhrase = result.company.catchPhrase,
                        Bs = result.company.bs
                    });

                    Add(new User
                    {
                        Id = result.id,
                        Name = result.name,
                        Username = result.username,
                        Email = result.email,

                        Address = userAddresses,

                        Phone = result.phone,
                        Website = result.website,

                        Company = userCompanies
                    }) ;                      
                }
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
