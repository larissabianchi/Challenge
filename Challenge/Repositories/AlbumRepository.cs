using Challenge.Interface;
using Challenge.Models;

namespace Challenge.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private List<Album> albums = new List<Album>();

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
