using Data.Context.Contract;
using Data.Entity.Model;
using Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class MerchRepository : IMerchRepository
    {
        private readonly IAuRhapsodyDBContext _auRhapsodyDBContext;

        MerchRepository(IAuRhapsodyDBContext dbContext)
        {
            _auRhapsodyDBContext = dbContext;
        }

        /// <summary>
        /// This method creates a Merch.
        /// </summary>
        /// <param name="merchToAdd"></param>
        /// <returns></returns>
        public async Task<Merch> CreateMerch(Merch merchToAdd)
        {
            var createdMerch = await _auRhapsodyDBContext.Merches.AddAsync(merchToAdd).ConfigureAwait(false);
            await _auRhapsodyDBContext.SaveChangesAsync().ConfigureAwait(false);

            return createdMerch.Entity;
        }

        /// <summary>
        /// This method updates a Merch.
        /// </summary>
        /// <param name="merchToUpdate"></param>
        /// <returns></returns>
        public async Task<Merch> UpdateMerch(Merch merchToUpdate)
        {
            var elementUptated = _auRhapsodyDBContext.Merches.Update(merchToUpdate);
            await _auRhapsodyDBContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUptated.Entity;
        }

        /// <summary>
        /// This method deletes a Merch.
        /// </summary>
        /// <param name="merchToDelete"></param>
        /// <returns></returns>
        public async Task<Merch> DeleteMerch(Merch merchToDelete)
        {
            var deletedMerch = _auRhapsodyDBContext.Merches.Remove(merchToDelete);
            await _auRhapsodyDBContext.SaveChangesAsync().ConfigureAwait(false);

            return deletedMerch.Entity;
        }

        /// <summary>
        /// This method reads one merch by its ID.
        /// </summary>
        /// <param name="merchId"></param>
        /// <returns></returns>
        public async Task<Merch> GetMerchById(int merchId)
        {
            return await _auRhapsodyDBContext.Merches
                .Include(x => x.Artists)
                .Include(x => x.Bands)
                .FirstOrDefaultAsync(x => x.MerchId == merchId)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// This method returns a list of merches.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Merch>> GetAllMerches(string? merchType = null, string? bandName = null, string? artistName = null, string? sortBy = null)
        {
            var query = _auRhapsodyDBContext.Merches
                .Include(x => x.Artists)
                .Include(x => x.Bands)
                .AsQueryable();

            // Filter by type if provided
            if (!string.IsNullOrEmpty(merchType))
            {
                query = query.Where(merch => merch.MerchType == merchType);
            }

            // Filter by artist if provided
            if (!string.IsNullOrEmpty(artistName))
            {
                query = query.Where(merch => merch.Artists.Any(artist => artist.ArtistName == artistName));
            }

            // Filter by band if provided
            if (!string.IsNullOrEmpty(bandName))
            {
                query = query.Where(merch => merch.Bands.Any(band => band.BandName == bandName));
            }

            // Sorting logic
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "dateofbirth":
                        query = query.OrderBy(merch => merch.MerchDate);
                        break;
                    default:
                        // Default sorting
                        query = query.OrderBy(merch => merch.MerchName);
                        break;
                }
            }

            return await query.ToListAsync().ConfigureAwait(false);
        }
    }
}
