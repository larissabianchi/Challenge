using Challenge.Interface;
using Challenge.Models;
using Challenge.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        static readonly IAlbumRepository repository = new AlbumRepository();
                
        [Route("/albums")]
        public IEnumerable<Album> GetAllAlbums()
        {
            return repository.GetAll();
        }

        [Route("/albums/id/{id}")]
        public Album GetAlbumById(int id)
        {
            Album item = repository.Get(id);

            if (item == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return item;
        }

        [Route("/albums/title/{title}")]
        public IEnumerable<Album> GetAlbumByTitle(string title)
        {
            return repository.GetAll().Where(
                album => string.Equals(album.Title, title, StringComparison.OrdinalIgnoreCase)    
            );
        }

        [Route("/albums/userId/{id}")]
        public IEnumerable<Album> GetAlbumByUserId(int id)
        {
            return repository.GetAll().Where(
                album => album.UserId == id
            );
        }
    }
}
