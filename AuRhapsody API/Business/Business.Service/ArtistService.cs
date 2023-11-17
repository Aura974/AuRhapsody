using Business.DTO.Artists;
using Business.Mapper.Artists;
using Business.Service.Contract;
using Data.Repository.Contract;

namespace Business.Service
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        /// <summary>
        /// Creates an Artist
        /// </summary>
        /// <param name="artistDTO">Artist data</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadArtistDTO> CreateArtist(CreateArtistDTO artistDTO)
        {
            if (artistDTO == null)
            {
                throw new ArgumentNullException(nameof(artistDTO));
            }

            var artistAdd = ArtistMapper.TransformCreateDTOToEntity(artistDTO);

            var artistAdded = await _artistRepository.CreateArtist(artistAdd).ConfigureAwait(false);

            return ArtistMapper.TransformEntityToReadArtistDTO(artistAdded);

        }

        /// <summary>
        /// Updates an Artist
        /// </summary>
        /// <param name="artistId"></param>
        /// <param name="artistDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadArtistDTO> UpdateArtist(int artistId, UpdateArtistDTO artistDto)
        {
            if (artistDto == null) throw new ArgumentNullException(nameof(artistDto));

            var artistToUpdate = await _artistRepository.GetArtistById(artistId).ConfigureAwait(false);

            if (artistToUpdate == null)
            {
                throw new Exception($"Artist update failure: no artist exists with this identifier {artistId}");
            }

            ArtistMapper.UpdateEntityFromUpdateDTO(artistToUpdate, artistDto);

            var artistUpdated = await _artistRepository.UpdateArtist(artistToUpdate).ConfigureAwait(false);

            return ArtistMapper.TransformEntityToReadArtistDTO(artistUpdated);
        }

        /// <summary>
        /// Deletes an Artist
        /// </summary>
        /// <param name="ArtistId">Artist ID</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ReadArtistDTO> DeleteArtist(int ArtistId)
        {
            var artistToDelete = await _artistRepository.GetArtistById(ArtistId).ConfigureAwait(false);

            if (artistToDelete == null)
            {
                throw new Exception($"Artist deletion failure: no artist exists with this identifier {ArtistId}");
            }

            await _artistRepository.DeleteArtist(artistToDelete).ConfigureAwait(false);

            return ArtistMapper.TransformEntityToReadArtistDTO(artistToDelete);
        }

        /// <summary>
        /// Returns an artist by its Id
        /// </summary>
        /// <param name="artistId"></param>
        /// <returns></returns>
        public async Task<ReadArtistDTO> GetArtistById(int artistId)
        {
            var artist = await _artistRepository.GetArtistById(artistId).ConfigureAwait(false);

            ReadArtistDTO readArtistDTO = ArtistMapper.TransformEntityToReadArtistDTO(artist);

            return readArtistDTO;
        }

        /// <summary>
        /// Returns a list of all artists.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReadArtistDTO>> GetAllArtists()
        {
            var artists = await _artistRepository.GetAllArtists().ConfigureAwait(false);

            List<ReadArtistDTO> readArtistDTOs = new List<ReadArtistDTO>();

            foreach (var artist in artists)
            {
                readArtistDTOs.Add(ArtistMapper.TransformEntityToReadArtistDTO(artist));
            }

            return readArtistDTOs;
        }
    }
}
