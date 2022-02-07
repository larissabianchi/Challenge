using Challenge.Interface;
using Challenge.Models;
using Challenge.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        static readonly IPhotoRepository repository = new PhotoRepository();

        [Route("/photos")]
        public IEnumerable<Photo> GetAllPhotos()
        {
            return repository.GetAll();
        }

        [Route("/photos/id/{id}")]
        public Photo GetPhotoById(int id)
        {
            Photo item = repository.Get(id);

            if(item == null)
            {
                throw new Exception("Sorry, we don't find the photo " + id);
            }

            return item;
        }

        [Route("/photos/albumId/{id}")]
        public IEnumerable<Photo> GetPhotoByAlbumId(int id)
        {
            return repository.GetAll().Where(
                photo => photo.AlbumId == id    
            );
        }

        [Route("/photos/title/{title}")]
        public IEnumerable<Photo> GetPhotoByTitle(string title)
        {
            return repository.GetAll().Where(
                photo => string.Equals(photo.Title, title, StringComparison.OrdinalIgnoreCase) 
            );
        }
    }
}
