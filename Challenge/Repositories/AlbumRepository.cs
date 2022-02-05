using Challenge.Interface;
using Challenge.Models;
using Newtonsoft.Json;
using System.Net;

namespace Challenge.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private List<Album> albums = new List<Album>();

        public AlbumRepository()
        {
            using (WebClient webClient = new WebClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                var json = webClient.DownloadString("https://jsonplaceholder.typicode.com/albums");
                dynamic album = JsonConvert.DeserializeObject(json);

                foreach (var result in album)
                {
                    var userId = result.userId;
                    var id = result.id;    
                    var title = result.title;

                    Add(new Album { 
                        UserId = userId, 
                        Id = id, 
                        Title = title 
                    });
                }
            }
        }

        public Album Add(Album item)
        {
            if (item == null)
            {
                throw new NotImplementedException();
            }

            albums.Add(item);

            return item;
        }

        public Album Get(int id)
        {
            return albums.Find(album => album.Id == id);
        }

        public IEnumerable<Album> GetAll()
        {
            return albums;
        }
    }
}
