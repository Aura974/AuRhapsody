using Business.DTO.Bands;

namespace Business.Service.Contract
{
    public interface IBandService
    {

        /// <summary>
        /// Creates an Band
        /// </summary>
        /// <param name="bandDTO">Band data</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadBandDTO> CreateBand(CreateBandDTO bandDTO);

        /// <summary>
        /// Updates an Band
        /// </summary>
        /// <param name="bandId"></param>
        /// <param name="bandDto"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        Task<ReadBandDTO> UpdateBand(int bandId, UpdateBandDTO bandDto);

        /// <summary>
        /// Deletes an Band
        /// </summary>
        /// <param name="BandId">Band ID</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<ReadBandDTO> DeleteBand(int BandId);

        /// <summary>
        /// Returns an band by its Id
        /// </summary>
        /// <param name="bandId"></param>
        /// <returns></returns>
        Task<ReadBandDTO> GetBandById(int bandId);

        /// <summary>
        /// Returns a list of all bands.
        /// </summary>
        /// <returns></returns>
        Task<List<ReadBandDTO>> GetAllBands();
    }
}
