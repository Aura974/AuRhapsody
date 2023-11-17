using Business.DTO.Singles;

namespace Business.Service.Contract
{
    public interface ISingleService
    {
        /// <summary>
        /// Creates a Single
        /// </summary>
        /// <param name="singleDTO">Single data</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadSingleDTO> CreateSingle(CreateSingleDTO singleDTO);

        /// <summary>
        /// Updates a Single
        /// </summary>
        /// <param name="singleId"></param>
        /// <param name="singleDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadSingleDTO> UpdateSingle(int singleId, UpdateSingleDTO singleDto);

        /// <summary>
        /// Deletes a Single
        /// </summary>
        /// <param name="SingleId">Single ID</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<ReadSingleDTO> DeleteSingle(int SingleId);

        /// <summary>
        /// Returns a single by its Id
        /// </summary>
        /// <param name="singleId"></param>
        /// <returns></returns>
        Task<ReadSingleDTO> GetSingleById(int singleId);

        /// <summary>
        /// Returns a list of all singles.
        /// </summary>
        /// <returns></returns>
        Task<List<ReadSingleDTO>> GetAllSingles();
    }
}
