using Challenge.Models;

namespace Challenge.Interface
{
    public interface IPhotoRepository
    {
        IEnumerable<Photo> GetAll();

        Photo Get(int id);

        Photo Add(Photo item);
    }
}
