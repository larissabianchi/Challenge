using Challenge.Models;

namespace Challenge.Interface
{
    public interface IAlbumRepository
    {
        IEnumerable<Album> GetAll();

        Album Get(int id);

        Album Add(Album item);
    }
}
