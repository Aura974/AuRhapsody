using Data.Entity.Model;

namespace Data.Repository.Contract
{
    public interface IAlbumRepository
    {
        /// <summary>
        /// This method creates an Album.
        /// </summary>
        /// <param name="albumToAdd"></param>
        /// <returns></returns>
        Task<Album> CreateAlbum(Album albumToAdd);

        /// <summary>
        /// This method updates an Album.
        /// </summary>
        /// <param name="albumToUpdate"></param>
        /// <returns></returns>
        Task<Album> UpdateAlbum(Album albumToUpdate);

        /// <summary>
        /// This method deletes an Album.
        /// </summary>
        /// <param name="albumToDelete"></param>
        /// <returns></returns>
        Task<Album> DeleteAlbum(Album albumToDelete);

        /// <summary>
        /// This method reads one album by its ID.
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        Task<Album> GetAlbumById(int albumId);

        /// <summary>
        /// This method returns a list of albums.
        /// </summary>
        /// <returns></returns>
        Task<List<Album>> GetAllAlbums(string? artistName = null, string? bandName = null, string? sortBy = null);
    }
}
