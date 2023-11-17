using Business.DTO.Merches;
using Business.Mapper.Merches;
using Business.Service.Contract;
using Data.Repository.Contract;

namespace Business.Service
{
    public class MerchService : IMerchService
    {
        private readonly IMerchRepository _merchRepository;

        public MerchService(IMerchRepository merchRepository)
        {
            _merchRepository = merchRepository;
        }

        /// <summary>
        /// Creates a Merch
        /// </summary>
        /// <param name="merchDTO">Merch data</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadMerchDTO> CreateMerch(CreateMerchDTO merchDTO)
        {
            if (merchDTO == null)
            {
                throw new ArgumentNullException(nameof(merchDTO));
            }

            var merchAdd = MerchMapper.TransformCreateDTOToEntity(merchDTO);

            var merchAdded = await _merchRepository.CreateMerch(merchAdd).ConfigureAwait(false);

            return MerchMapper.TransformEntityToReadMerchDTO(merchAdded);

        }

        /// <summary>
        /// Updates a Merch
        /// </summary>
        /// <param name="merchId"></param>
        /// <param name="merchDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<ReadMerchDTO> UpdateMerch(int merchId, UpdateMerchDTO merchDto)
        {
            if (merchDto == null) throw new ArgumentNullException(nameof(merchDto));

            var merchToUpdate = await _merchRepository.GetMerchById(merchId).ConfigureAwait(false);

            if (merchToUpdate == null)
            {
                throw new Exception($"Merch update failure: no merch exists with this identifier {merchId}");
            }

            MerchMapper.UpdateEntityFromUpdateDTO(merchToUpdate, merchDto);

            var merchUpdated = await _merchRepository.UpdateMerch(merchToUpdate).ConfigureAwait(false);

            return MerchMapper.TransformEntityToReadMerchDTO(merchUpdated);
        }

        /// <summary>
        /// Deletes a Merch
        /// </summary>
        /// <param name="MerchId">Merch ID</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ReadMerchDTO> DeleteMerch(int MerchId)
        {
            var merchToDelete = await _merchRepository.GetMerchById(MerchId).ConfigureAwait(false);

            if (merchToDelete == null)
            {
                throw new Exception($"Merch deletion failure: no merch exists with this identifier {MerchId}");
            }

            await _merchRepository.DeleteMerch(merchToDelete).ConfigureAwait(false);

            return MerchMapper.TransformEntityToReadMerchDTO(merchToDelete);
        }

        /// <summary>
        /// Returns a merch by its Id
        /// </summary>
        /// <param name="merchId"></param>
        /// <returns></returns>
        public async Task<ReadMerchDTO> GetMerchById(int merchId)
        {
            var merch = await _merchRepository.GetMerchById(merchId).ConfigureAwait(false);

            ReadMerchDTO readMerchDTO = MerchMapper.TransformEntityToReadMerchDTO(merch);

            return readMerchDTO;
        }

        /// <summary>
        /// Returns a list of all merches.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReadMerchDTO>> GetAllMerches()
        {
            var merches = await _merchRepository.GetAllMerches().ConfigureAwait(false);

            List<ReadMerchDTO> readMerchDTOs = new List<ReadMerchDTO>();

            foreach (var merch in merches)
            {
                readMerchDTOs.Add(MerchMapper.TransformEntityToReadMerchDTO(merch));
            }

            return readMerchDTOs;
        }
    }
}
