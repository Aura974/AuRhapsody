using Data.Context.Contract;
using Data.Entity.Model;
using Data.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly IAuRhapsodyDBContext _auRhapsodyDBContext;

        AlbumRepository(IAuRhapsodyDBContext dbContext)
        {
            _auRhapsodyDBContext = dbContext;
        }

        /// <summary>
        /// This method creates an Album.
        /// </summary>
        /// <param name="albumToAdd"></param>
        /// <returns></returns>
        public async Task<Album> CreateAlbum(Album albumToAdd)
        {
            var createdAlbum = await _auRhapsodyDBContext.Albums.AddAsync(albumToAdd).ConfigureAwait(false);
            await _auRhapsodyDBContext.SaveChangesAsync().ConfigureAwait(false);

            return createdAlbum.Entity;
        }

        /// <summary>
        /// This method updates an Album.
        /// </summary>
        /// <param name="albumToUpdate"></param>
        /// <returns></returns>
        public async Task<Album> UpdateAlbum(Album albumToUpdate)
        {
            var elementUptated = _auRhapsodyDBContext.Albums.Update(albumToUpdate);
            await _auRhapsodyDBContext.SaveChangesAsync().ConfigureAwait(false);

            return elementUptated.Entity;
        }

        /// <summary>
        /// This method deletes an Album.
        /// </summary>
        /// <param name="albumToDelete"></param>
        /// <returns></returns>
        public async Task<Album> DeleteAlbum(Album albumToDelete)
        {
            var deletedAlbum = _auRhapsodyDBContext.Albums.Remove(albumToDelete);
            await _auRhapsodyDBContext.SaveChangesAsync().ConfigureAwait(false);

            return deletedAlbum.Entity;
        }

        /// <summary>
        /// This method reads one album by its ID.
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        public async Task<Album> GetAlbumById(int albumId)
        {
            return await _auRhapsodyDBContext.Albums
                .Include(x => x.Artists)
                .Include(x => x.Bands)
                .FirstOrDefaultAsync(x => x.AlbumId == albumId)
                .ConfigureAwait(false);
        }


        /// <summary>
        /// This method returns a list of albums.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Album>> GetAllAlbums(string? artistName = null, string? bandName = null, string? sortBy = null)
        {
            var query = _auRhapsodyDBContext.Albums
                .Include(x => x.Artists)
                .Include(x => x.Bands)
                .AsQueryable();

            // Filter by artist if provided
            if (!string.IsNullOrEmpty(artistName))
            {
                query = query.Where(album => album.Artists.Any(artist => artist.ArtistName == artistName));
            }

            // Filter by band if provided
            if (!string.IsNullOrEmpty(bandName))
            {
                query = query.Where(album => album.Bands.Any(band => band.BandName == bandName));
            }

            // Sorting logic
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "releasedate":
                        query = query.OrderBy(album => album.AlbumReleaseDate);
                        break;
                    default:
                        // Default sorting
                        query = query.OrderBy(album => album.AlbumTitle);
                        break;
                }
            }

            return await query.ToListAsync().ConfigureAwait(false);
        }
    }
}
