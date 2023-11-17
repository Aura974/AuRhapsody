using Business.DTO.Albums;

namespace Business.Service.Contract
{
    public interface IAlbumService
    {
        /// <summary>
        /// Creates an Album
        /// </summary>
        /// <param name="albumDTO">Album data</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadAlbumDTO> CreateAlbum(CreateAlbumDTO albumDTO);

        /// <summary>
        /// Updates an Album
        /// </summary>
        /// <param name="albumId"></param>
        /// <param name="albumDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadAlbumDTO> UpdateAlbum(int albumId, UpdateAlbumDTO albumDto);

        /// <summary>
        /// Deletes an Album
        /// </summary>
        /// <param name="AlbumId">Album ID</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<ReadAlbumDTO> DeleteAlbum(int AlbumId);

        /// <summary>
        /// Returns an album by its Id
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        Task<ReadAlbumDTO> GetAlbumById(int albumId);

        /// <summary>
        /// Returns a list of all albums.
        /// </summary>
        /// <returns></returns>
        Task<List<ReadAlbumDTO>> GetAllAlbums(string? artistName = null, string? bandName = null, string? sortBy = null);
    }
}
