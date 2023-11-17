using Business.DTO.Merches;

namespace Business.Service.Contract
{
    public interface IMerchService
    {
        /// <summary>
        /// Creates a Merch
        /// </summary>
        /// <param name="merchDTO">Merch data</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadMerchDTO> CreateMerch(CreateMerchDTO merchDTO);

        /// <summary>
        /// Updates a Merch
        /// </summary>
        /// <param name="merchId"></param>
        /// <param name="merchDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadMerchDTO> UpdateMerch(int merchId, UpdateMerchDTO merchDto);

        /// <summary>
        /// Deletes a Merch
        /// </summary>
        /// <param name="MerchId">Merch ID</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<ReadMerchDTO> DeleteMerch(int MerchId);

        /// <summary>
        /// Returns a merch by its Id
        /// </summary>
        /// <param name="merchId"></param>
        /// <returns></returns>
        Task<ReadMerchDTO> GetMerchById(int merchId);

        /// <summary>
        /// Returns a list of all merches.
        /// </summary>
        /// <returns></returns>
        Task<List<ReadMerchDTO>> GetAllMerches();
    }
}
