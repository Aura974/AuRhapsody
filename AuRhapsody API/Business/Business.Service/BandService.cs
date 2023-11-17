using Business.DTO.Bands;
using Business.Mapper.Bands;
using Business.Service.Contract;
using Data.Repository.Contract;

namespace Business.Service
{
    public class BandService : IBandService
    {
        private readonly IBandRepository _bandRepository;

        public BandService(IBandRepository bandRepository)
        {
            _bandRepository = bandRepository;
        }

        /// <summary>
        /// Creates a Band
        /// </summary>
        /// <param name="bandDTO">Band data</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadBandDTO> CreateBand(CreateBandDTO bandDTO)
        {
            if (bandDTO == null)
            {
                throw new ArgumentNullException(nameof(bandDTO));
            }

            var bandAdd = BandMapper.TransformCreateDTOToEntity(bandDTO);

            var bandAdded = await _bandRepository.CreateBand(bandAdd).ConfigureAwait(false);

            return BandMapper.TransformEntityToReadBandDTO(bandAdded);

        }

        /// <summary>
        /// Updates a Band
        /// </summary>
        /// <param name="bandId"></param>
        /// <param name="bandDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadBandDTO> UpdateBand(int bandId, UpdateBandDTO bandDto)
        {
            if (bandDto == null) throw new ArgumentNullException(nameof(bandDto));

            var bandToUpdate = await _bandRepository.GetBandById(bandId).ConfigureAwait(false);

            if (bandToUpdate == null)
            {
                throw new Exception($"Band update failure: no band exists with this identifier {bandId}");
            }

            BandMapper.UpdateEntityFromUpdateDTO(bandToUpdate, bandDto);

            var bandUpdated = await _bandRepository.UpdateBand(bandToUpdate).ConfigureAwait(false);

            return BandMapper.TransformEntityToReadBandDTO(bandUpdated);
        }

        /// <summary>
        /// Deletes a Band
        /// </summary>
        /// <param name="BandId">Band ID</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ReadBandDTO> DeleteBand(int BandId)
        {
            var bandToDelete = await _bandRepository.GetBandById(BandId).ConfigureAwait(false);

            if (bandToDelete == null)
            {
                throw new Exception($"Band deletion failure: no band exists with this identifier {BandId}");
            }

            await _bandRepository.DeleteBand(bandToDelete).ConfigureAwait(false);

            return BandMapper.TransformEntityToReadBandDTO(bandToDelete);
        }

        /// <summary>
        /// Returns a band by its Id
        /// </summary>
        /// <param name="bandId"></param>
        /// <returns></returns>
        public async Task<ReadBandDTO> GetBandById(int bandId)
        {
            var band = await _bandRepository.GetBandById(bandId).ConfigureAwait(false);

            ReadBandDTO readBandDTO = BandMapper.TransformEntityToReadBandDTO(band);

            return readBandDTO;
        }

        /// <summary>
        /// Returns a list of all bands.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReadBandDTO>> GetAllBands()
        {
            var bands = await _bandRepository.GetAllBands().ConfigureAwait(false);

            List<ReadBandDTO> readBandDTOs = new List<ReadBandDTO>();

            foreach (var band in bands)
            {
                readBandDTOs.Add(BandMapper.TransformEntityToReadBandDTO(band));
            }

            return readBandDTOs;
        }
    }
}
