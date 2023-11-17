using Data.Entity.Model;

namespace Data.Repository.Contract
{
    public interface IArtistRepository
    {
        /// <summary>
        /// This method creates an Artist.
        /// </summary>
        /// <param name="artistToAdd"></param>
        /// <returns></returns>
        Task<Artist> CreateArtist(Artist artistToAdd);

        /// <summary>
        /// This method updates an Artist.
        /// </summary>
        /// <param name="artistToUpdate"></param>
        /// <returns></returns>
        Task<Artist> UpdateArtist(Artist artistToUpdate);

        /// <summary>
        /// This method deletes an Artist.
        /// </summary>
        /// <param name="artistToDelete"></param>
        /// <returns></returns>
        Task<Artist> DeleteArtist(Artist artistToDelete);

        /// <summary>
        /// This method reads one artist by its ID.
        /// </summary>
        /// <param name="artistId"></param>
        /// <returns></returns>
        Task<Artist> GetArtistById(int artistId);

        /// <summary>
        /// This method returns a list of artists.
        /// </summary>
        /// <returns></returns>
        Task<List<Artist>> GetAllArtists(string? albumTitle = null, string? bandName = null, string? sortBy = null);
    }
}
