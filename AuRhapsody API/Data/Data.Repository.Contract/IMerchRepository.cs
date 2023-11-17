using Data.Entity.Model;

namespace Data.Repository.Contract
{
    public interface IMerchRepository
    {
        /// <summary>
        /// This method creates a Merch.
        /// </summary>
        /// <param name="merchToAdd"></param>
        /// <returns></returns>
        Task<Merch> CreateMerch(Merch merchToAdd);

        /// <summary>
        /// This method updates a Merch.
        /// </summary>
        /// <param name="merchToUpdate"></param>
        /// <returns></returns>
        Task<Merch> UpdateMerch(Merch merchToUpdate);

        /// <summary>
        /// This method deletes a Merch.
        /// </summary>
        /// <param name="merchToDelete"></param>
        /// <returns></returns>
        Task<Merch> DeleteMerch(Merch merchToDelete);

        /// <summary>
        /// This method reads one merch by its ID.
        /// </summary>
        /// <param name="merchId"></param>
        /// <returns></returns>
        Task<Merch> GetMerchById(int merchId);

        /// <summary>
        /// This method returns a list of merches.
        /// </summary>
        /// <returns></returns>
        Task<List<Merch>> GetAllMerches(string? merchType = null, string? bandName = null, string? artistName = null, string? sortBy = null);
    }
}
