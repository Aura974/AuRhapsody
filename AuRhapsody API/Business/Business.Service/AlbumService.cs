using Business.DTO.Albums;
using Business.Mapper.Albums;
using Business.Service.Contract;
using Data.Repository.Contract;

namespace Business.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        /// <summary>
        /// Creates an Album
        /// </summary>
        /// <param name="albumDTO">Album data</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadAlbumDTO> CreateAlbum(CreateAlbumDTO albumDTO)
        {
            if (albumDTO == null)
            {
                throw new ArgumentNullException(nameof(albumDTO));
            }

            var albumAdd = AlbumMapper.TransformCreateDTOToEntity(albumDTO);

            var albumAdded = await _albumRepository.CreateAlbum(albumAdd).ConfigureAwait(false);

            return AlbumMapper.TransformEntityToReadAlbumDTO(albumAdded);

        }

        /// <summary>
        /// Updates an Album
        /// </summary>
        /// <param name="albumId"></param>
        /// <param name="albumDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadAlbumDTO> UpdateAlbum(int albumId, UpdateAlbumDTO albumDto)
        {
            if (albumDto == null) throw new ArgumentNullException(nameof(albumDto));

            var albumToUpdate = await _albumRepository.GetAlbumById(albumId).ConfigureAwait(false);

            if (albumToUpdate == null)
            {
                throw new Exception($"Album update failure: no album exists with this identifier {albumId}");
            }

            AlbumMapper.UpdateEntityFromUpdateDTO(albumToUpdate, albumDto);

            var albumUpdated = await _albumRepository.UpdateAlbum(albumToUpdate).ConfigureAwait(false);

            return AlbumMapper.TransformEntityToReadAlbumDTO(albumUpdated);
        }

        /// <summary>
        /// Deletes an Album
        /// </summary>
        /// <param name="AlbumId">Album ID</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ReadAlbumDTO> DeleteAlbum(int AlbumId)
        {
            var albumToDelete = await _albumRepository.GetAlbumById(AlbumId).ConfigureAwait(false);

            if (albumToDelete == null)
            {
                throw new Exception($"Album deletion failure: no album exists with this identifier {AlbumId}");
            }

            await _albumRepository.DeleteAlbum(albumToDelete).ConfigureAwait(false);

            return AlbumMapper.TransformEntityToReadAlbumDTO(albumToDelete);
        }

        /// <summary>
        /// Returns an album by its Id
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        public async Task<ReadAlbumDTO> GetAlbumById(int albumId)
        {
            var album = await _albumRepository.GetAlbumById(albumId).ConfigureAwait(false);

            ReadAlbumDTO readAlbumDTO = AlbumMapper.TransformEntityToReadAlbumDTO(album);

            return readAlbumDTO;
        }

        /// <summary>
        /// Returns a list of all albums.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReadAlbumDTO>> GetAllAlbums()
        {
            var albums = await _albumRepository.GetAllAlbums().ConfigureAwait(false);

            List<ReadAlbumDTO> readAlbumDTOs = new List<ReadAlbumDTO>();

            foreach (var album in albums)
            {
                readAlbumDTOs.Add(AlbumMapper.TransformEntityToReadAlbumDTO(album));
            }

            return readAlbumDTOs;
        }
    }
}
