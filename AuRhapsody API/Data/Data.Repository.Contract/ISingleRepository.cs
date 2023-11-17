using Single = Data.Entity.Model.Single;

namespace Data.Repository.Contract
{
    public interface ISingleRepository
    {
        /// <summary>
        /// This method creates a Single.
        /// </summary>
        /// <param name="singleToAdd"></param>
        /// <returns></returns>
        Task<Single> CreateSingle(Single singleToAdd);

        /// <summary>
        /// This method updates a Single.
        /// </summary>
        /// <param name="singleToUpdate"></param>
        /// <returns></returns>
        Task<Single> UpdateSingle(Single singleToUpdate);

        /// <summary>
        /// This method deletes a Single.
        /// </summary>
        /// <param name="singleToDelete"></param>
        /// <returns></returns>
        Task<Single> DeleteSingle(Single singleToDelete);

        /// <summary>
        /// This method reads one single by its ID.
        /// </summary>
        /// <param name="singleId"></param>
        /// <returns></returns>
        Task<Single> GetSingleById(int singleId);

        /// <summary>
        /// This method returns a list of singles.
        /// </summary>
        /// <returns></returns>
        Task<List<Single>> GetAllSingles(string? artistName = null, string? bandName = null, string? sortBy = null);
    }
}
