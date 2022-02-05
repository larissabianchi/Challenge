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
                    var id = result.id;
                    var name = result.name;
                    var username = result.username;
                    var email = result.email;
                    
                    var addStreet = result.address.street;
                    var addSuite = result.address.suite;
                    var addCity = result.address.city;
                    var addZipcode = result.address.zipcode;

                    var addGeoLat = result.address.geo.lat;
                    var addGeoLng = result.address.geo.lng;

                    var phone = result.phone;
                    var website = result.website;

                    var compName = result.company.name;
                    var compCatchPhrase = result.company.catchPhrase;
                    var compBs = result.company.bs;

                    Add(new User
                    {
                        Id = id,
                        Name = name,
                        Username = username,
                        Email = email,
                        Phone = phone,
                        Website = website
                    }) ;

                    userAddresses.Add(new UserAddress
                    {
                        Street = addStreet,
                        Suite = addSuite,
                        City = addCity,
                        Zipcode = addZipcode
                    });

                    userAddressGeos.Add(new UserAddressGeo
                    {
                        Lat = addGeoLat,
                        Lng = addGeoLng
                    });

                    userCompanies.Add(new UserCompany
                    {
                        Name = compName,
                        CatchPhrase = compCatchPhrase,
                        Bs = compBs
                    });
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
