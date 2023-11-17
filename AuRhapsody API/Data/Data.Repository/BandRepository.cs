using Data.Context.Contract;
using Data.Entity.Model;
using Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class BandRepository : IBandRepository
    {
        private readonly IAuRhapsodyDBContext _auRhapsodyDBContext;

        BandRepository(IAuRhapsodyDBContext dbContext)
        {
            _auRhapsodyDBContext = dbContext;
        }

        /// <summary>
        /// This method creates a Band.
        /// </summary>
        /// <param name="bandToAdd"></param>
        /// <returns></returns>
        public async Task<Band> CreateBand(Band bandToAdd)
        {
            var createdBand = await _auRhapsodyDBContext.Bands.AddAsync(bandToAdd).ConfigureAwait(false);
            await _auRhapsodyDBContext.SaveChangesAsync().ConfigureAwait(false);

            return createdBand.Entity;
        }

        /// <summary>
        /// This method updates a Band.
        /// </summary>
        /// <param name="bandToUpdate"></param>
        /// <returns></returns>
        public async Task<Band> UpdateBand(Band bandToUpdate)
        {
            var elementUptated = _auRhapsodyDBContext.Bands.Update(bandToUpdate);
            await _auRhapsodyDBContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUptated.Entity;
        }

        /// <summary>
        /// This method deletes a Band.
        /// </summary>
        /// <param name="bandToDelete"></param>
        /// <returns></returns>
        public async Task<Band> DeleteBand(Band bandToDelete)
        {
            var deletedBand = _auRhapsodyDBContext.Bands.Remove(bandToDelete);
            await _auRhapsodyDBContext.SaveChangesAsync().ConfigureAwait(false);

            return deletedBand.Entity;
        }

        /// <summary>
        /// This method reads one band by its ID.
        /// </summary>
        /// <param name="bandId"></param>
        /// <returns></returns>
        public async Task<Band> GetBandById(int bandId)
        {
            return await _auRhapsodyDBContext.Bands
                .Include(x => x.Albums)
                .Include(x => x.Artists)
                .Include(x => x.Merches)
                .Include(x => x.Singles)
                .FirstOrDefaultAsync(x => x.BandId == bandId)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// This method returns a list of bands.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Band>> GetAllBands(string? albumTitle = null, string? artistName = null, string? sortBy = null)
        {
            var query = _auRhapsodyDBContext.Bands
                .Include(x => x.Albums)
                .Include(x => x.Artists)
                .Include(x => x.Merches)
                .Include(x => x.Singles)
                .AsQueryable();

            // Filter by album if provided
            if (!string.IsNullOrEmpty(albumTitle))
            {
                query = query.Where(band => band.Albums.Any(album => album.AlbumTitle == albumTitle));
            }

            // Filter by artist if provided
            if (!string.IsNullOrEmpty(artistName))
            {
                query = query.Where(artist => artist.Artists.Any(artist => artist.ArtistName == artistName));
            }

            // Sorting logic
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "dateofbirth":
                        query = query.OrderBy(band => band.DateOfCreation);
                        break;
                    default:
                        // Default sorting
                        query = query.OrderBy(band => band.BandName);
                        break;
                }
            }

            return await query.ToListAsync().ConfigureAwait(false);
        }
    }
}
