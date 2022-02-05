using Challenge.Interface;
using Challenge.Models;
using Challenge.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    [Route("photos")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        static readonly IPhotoRepository repository = new PhotoRepository();

        public IEnumerable<Photo> GetAllPhotos()
        {
            return repository.GetAll();
        }

        //public Photo GetPhotoById(int id)
        //{
        //    Photo item = repository.Get(id);

        //    if(item == null)
        //    {
        //        //throw new HttpResponseException(HttpStatusCode.NotFound);
        //    }

        //    return item;
        //}

        //public IEnumerable<Photo> GetPhotoByAlbumId(int albumId)
        //{
        //    return repository.GetAll().Where(
        //        photo => photo.AlbumId == albumId    
        //    );
        //}

        //public IEnumerable<Photo> GetPhotoByTitle(string title)
        //{
        //    return repository.GetAll().Where(
        //        photo => string.Equals(photo.Title, title, StringComparison.OrdinalIgnoreCase) 
        //    );
        //}
    }
}
