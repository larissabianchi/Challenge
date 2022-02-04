using Challenge.Interface;
using Challenge.Models;

namespace Challenge.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private List<Photo> photos = new List<Photo>();

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
