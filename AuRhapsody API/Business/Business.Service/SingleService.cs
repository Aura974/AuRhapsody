using Business.DTO.Singles;
using Business.Mapper.Singles;
using Business.Service.Contract;
using Data.Repository.Contract;

namespace Business.Service
{
    public class SingleService : ISingleService
    {
        private readonly ISingleRepository _singleRepository;

        public SingleService(ISingleRepository singleRepository)
        {
            _singleRepository = singleRepository;
        }

        /// <summary>
        /// Creates a Single
        /// </summary>
        /// <param name="singleDTO">Single data</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadSingleDTO> CreateSingle(CreateSingleDTO singleDTO)
        {
            if (singleDTO == null)
            {
                throw new ArgumentNullException(nameof(singleDTO));
            }

            var singleAdd = SingleMapper.TransformCreateDTOToEntity(singleDTO);

            var singleAdded = await _singleRepository.CreateSingle(singleAdd).ConfigureAwait(false);

            return SingleMapper.TransformEntityToReadSingleDTO(singleAdded);

        }

        /// <summary>
        /// Updates a Single
        /// </summary>
        /// <param name="singleId"></param>
        /// <param name="singleDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadSingleDTO> UpdateSingle(int singleId, UpdateSingleDTO singleDto)
        {
            if (singleDto == null) throw new ArgumentNullException(nameof(singleDto));

            var singleToUpdate = await _singleRepository.GetSingleById(singleId).ConfigureAwait(false);

            if (singleToUpdate == null)
            {
                throw new Exception($"Single update failure: no single exists with this identifier {singleId}");
            }

            SingleMapper.UpdateEntityFromUpdateDTO(singleToUpdate, singleDto);

            var singleUpdated = await _singleRepository.UpdateSingle(singleToUpdate).ConfigureAwait(false);

            return SingleMapper.TransformEntityToReadSingleDTO(singleUpdated);
        }

        /// <summary>
        /// Deletes a Single
        /// </summary>
        /// <param name="SingleId">Single ID</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ReadSingleDTO> DeleteSingle(int SingleId)
        {
            var singleToDelete = await _singleRepository.GetSingleById(SingleId).ConfigureAwait(false);

            if (singleToDelete == null)
            {
                throw new Exception($"Single deletion failure: no single exists with this identifier {SingleId}");
            }

            await _singleRepository.DeleteSingle(singleToDelete).ConfigureAwait(false);

            return SingleMapper.TransformEntityToReadSingleDTO(singleToDelete);
        }

        /// <summary>
        /// Returns a single by its Id
        /// </summary>
        /// <param name="singleId"></param>
        /// <returns></returns>
        public async Task<ReadSingleDTO> GetSingleById(int singleId)
        {
            var single = await _singleRepository.GetSingleById(singleId).ConfigureAwait(false);

            ReadSingleDTO readSingleDTO = SingleMapper.TransformEntityToReadSingleDTO(single);

            return readSingleDTO;
        }

        /// <summary>
        /// Returns a list of all singles.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReadSingleDTO>> GetAllSingles()
        {
            var singles = await _singleRepository.GetAllSingles().ConfigureAwait(false);

            List<ReadSingleDTO> readSingleDTOs = new List<ReadSingleDTO>();

            foreach (var single in singles)
            {
                readSingleDTOs.Add(SingleMapper.TransformEntityToReadSingleDTO(single));
            }

            return readSingleDTOs;
        }
    }
}
