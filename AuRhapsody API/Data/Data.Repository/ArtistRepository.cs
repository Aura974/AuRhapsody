using Data.Context.Contract;
using Data.Entity.Model;
using Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly IAuRhapsodyDBContext _auRhapsodyDBContext;

        ArtistRepository(IAuRhapsodyDBContext dbContext)
        {
            _auRhapsodyDBContext = dbContext;
        }

        /// <summary>
        /// This method creates an Artist.
        /// </summary>
        /// <param name="artistToAdd"></param>
        /// <returns></returns>
        public async Task<Artist> CreateArtist(Artist artistToAdd)
        {
            var createdArtist = await _auRhapsodyDBContext.Artists.AddAsync(artistToAdd).ConfigureAwait(false);
            await _auRhapsodyDBContext.SaveChangesAsync().ConfigureAwait(false);

            return createdArtist.Entity;
        }

        /// <summary>
        /// This method updates an Artist.
        /// </summary>
        /// <param name="artistToUpdate"></param>
        /// <returns></returns>
        public async Task<Artist> UpdateArtist(Artist artistToUpdate)
        {
            var elementUptated = _auRhapsodyDBContext.Artists.Update(artistToUpdate);
            await _auRhapsodyDBContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUptated.Entity;
        }

        /// <summary>
        /// This method deletes an Artist.
        /// </summary>
        /// <param name="artistToDelete"></param>
        /// <returns></returns>
        public async Task<Artist> DeleteArtist(Artist artistToDelete)
        {
            var deletedArtist = _auRhapsodyDBContext.Artists.Remove(artistToDelete);
            await _auRhapsodyDBContext.SaveChangesAsync().ConfigureAwait(false);

            return deletedArtist.Entity;
        }

        /// <summary>
        /// This method reads one artist by its ID.
        /// </summary>
        /// <param name="artistId"></param>
        /// <returns></returns>
        public async Task<Artist> GetArtistById(int artistId)
        {
            return await _auRhapsodyDBContext.Artists
                .Include(x => x.Albums)
                .Include(x => x.Bands)
                .Include(x => x.Merches)
                .Include(x => x.Singles)
                .FirstOrDefaultAsync(x => x.ArtistId == artistId)
                .ConfigureAwait(false);
        }

        /// <summary>
        /// This method returns a list of artists.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Artist>> GetAllArtists(string? albumTitle = null, string? bandName = null, string? sortBy = null)
        {
            var query = _auRhapsodyDBContext.Artists
                .Include(x => x.Albums)
                .Include(x => x.Bands)
                .Include(x => x.Merches)
                .Include(x => x.Singles)
                .AsQueryable();

            // Filter by album if provided
            if (!string.IsNullOrEmpty(albumTitle))
            {
                query = query.Where(artist => artist.Albums.Any(album => album.AlbumTitle == albumTitle));
            }

            // Filter by band if provided
            if (!string.IsNullOrEmpty(bandName))
            {
                query = query.Where(artist => artist.Bands.Any(band => band.BandName == bandName));
            }

            // Sorting logic
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "dateofbirth":
                        query = query.OrderBy(artist => artist.DateOfBirth);
                        break;
                    default:
                        // Default sorting
                        query = query.OrderBy(artist => artist.ArtistName);
                        break;
                }
            }

            return await query.ToListAsync().ConfigureAwait(false);
        }
    }
}
