using Challenge.Interface;
using Challenge.Models;
using Newtonsoft.Json;
using System.Net;

namespace Challenge.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private List<Photo> photos = new List<Photo>();

        public PhotoRepository()
        {
            using (WebClient webClient = new WebClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
                var json = webClient.DownloadString("https://jsonplaceholder.typicode.com/photos");
                dynamic photo = JsonConvert.DeserializeObject(json);

                foreach (var result in photo)
                {
                    var albumId = result.albumId;
                    var id = result.id;
                    var title = result.title;
                    var url = result.url;
                    var thumbnailUrl = result.thumbnailUrl;

                    Add(new Photo{ 
                        AlbumId = albumId, 
                        Id = id, 
                        Title = title, 
                        Url = url, 
                        ThumbnailUrl = thumbnailUrl 
                    });
                }
            }
        }

        public Photo Add(Photo item)
        {
            if(item == null)
            {
                throw new NotImplementedException();
            }

            photos.Add(item);

            return item;
        }

        public Photo Get(int id)
        {
            return photos.Find(photo => photo.Id == id);
        }

        public IEnumerable<Photo> GetAll()
        {
            return photos;
        }
    }
}
