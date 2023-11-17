using Business.DTO.Artists;

namespace Business.Service.Contract
{
    public interface IArtistService
    {
        /// <summary>
        /// Creates an Artist
        /// </summary>
        /// <param name="artistDTO">Artist data</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadArtistDTO> CreateArtist(CreateArtistDTO artistDTO);

        /// <summary>
        /// Updates an Artist
        /// </summary>
        /// <param name="artistId"></param>
        /// <param name="artistDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadArtistDTO> UpdateArtist(int artistId, UpdateArtistDTO artistDto);

        /// <summary>
        /// Deletes an Artist
        /// </summary>
        /// <param name="ArtistId">Artist ID</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<ReadArtistDTO> DeleteArtist(int ArtistId);

        /// <summary>
        /// Returns an artist by its Id
        /// </summary>
        /// <param name="artistId"></param>
        /// <returns></returns>
        Task<ReadArtistDTO> GetArtistById(int artistId);

        /// <summary>
        /// Returns a list of all artists.
        /// </summary>
        /// <returns></returns>
        Task<List<ReadArtistDTO>> GetAllArtists();
    }
}
