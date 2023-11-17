using Data.Context.Contract;
using Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using Single = Data.Entity.Model.Single;

namespace Data.Repository
{
    public class SingleRepository : ISingleRepository
    {
        private readonly IAuRhapsodyDBContext _auRhapsodyDBContext;

        SingleRepository(IAuRhapsodyDBContext dbContext)
        {
            _auRhapsodyDBContext = dbContext;
        }

        /// <summary>
        /// This method creates a Single.
        /// </summary>
        /// <param name="singleToAdd"></param>
        /// <returns></returns>
        public async Task<Single> CreateSingle(Single singleToAdd)
        {
            var createdSingle = await _auRhapsodyDBContext.Singles.AddAsync(singleToAdd).ConfigureAwait(false);
            await _auRhapsodyDBContext.SaveChangesAsync().ConfigureAwait(false);

            return createdSingle.Entity;
        }

        /// <summary>
        /// This method updates a Single.
        /// </summary>
        /// <param name="singleToUpdate"></param>
        /// <returns></returns>
        public async Task<Single> UpdateSingle(Single singleToUpdate)
        {
            var elementUptated = _auRhapsodyDBContext.Singles.Update(singleToUpdate);
            await _auRhapsodyDBContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUptated.Entity;
        }

        /// <summary>
        /// This method deletes a Single.
        /// </summary>
        /// <param name="singleToDelete"></param>
        /// <returns></returns>
        public async Task<Single> DeleteSingle(Single singleToDelete)
        {
            var deletedSingle = _auRhapsodyDBContext.Singles.Remove(singleToDelete);
            await _auRhapsodyDBContext.SaveChangesAsync().ConfigureAwait(false);

            return deletedSingle.Entity;
        }

        /// <summary>
        /// This method reads one single by its ID.
        /// </summary>
        /// <param name="singleId"></param>
        /// <returns></returns>
        public async Task<Single> GetSingleById(int singleId)
        {
            return await _auRhapsodyDBContext.Singles
                .Include(x => x.Artists)
                .Include(x => x.Bands)
                .FirstOrDefaultAsync(x => x.SingleId == singleId)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// This method returns a list of singles.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Single>> GetAllSingles(string? artistName = null, string? bandName = null, string? sortBy = null)
        {
            var query = _auRhapsodyDBContext.Singles
                .Include(x => x.Artists)
                .Include(x => x.Bands)
                .AsQueryable();

            // Filter by artist if provided
            if (!string.IsNullOrEmpty(artistName))
            {
                query = query.Where(single => single.Artists.Any(artist => artist.ArtistName == artistName));
            }

            // Filter by band if provided
            if (!string.IsNullOrEmpty(bandName))
            {
                query = query.Where(single => single.Bands.Any(band => band.BandName == bandName));
            }

            // Sorting logic
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "releasedate":
                        query = query.OrderBy(single => single.SingleReleaseDate);
                        break;
                    default:
                        // Default sorting
                        query = query.OrderBy(single => single.SingleTitle);
                        break;
                }
            }

            return await query.ToListAsync().ConfigureAwait(false);
        }
    }
}
