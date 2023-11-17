using Data.Entity.Model;

namespace Data.Repository.Contract
{
    public interface IBandRepository
    {
        /// <summary>
        /// This method creates a Band.
        /// </summary>
        /// <param name="bandToAdd"></param>
        /// <returns></returns>
        Task<Band> CreateBand(Band bandToAdd);

        /// <summary>
        /// This method updates a Band.
        /// </summary>
        /// <param name="bandToUpdate"></param>
        /// <returns></returns>
        Task<Band> UpdateBand(Band bandToUpdate);

        /// <summary>
        /// This method deletes a Band.
        /// </summary>
        /// <param name="bandToDelete"></param>
        /// <returns></returns>
        Task<Band> DeleteBand(Band bandToDelete);

        /// <summary>
        /// This method reads one band by its ID.
        /// </summary>
        /// <param name="bandId"></param>
        /// <returns></returns>
        Task<Band> GetBandById(int bandId);

        /// <summary>
        /// This method returns a list of bands.
        /// </summary>
        /// <returns></returns>
        Task<List<Band>> GetAllBands(string? albumTitle = null, string? artistName = null, string? sortBy = null);
    }
}
