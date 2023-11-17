using Business.DTO.Albums;
using Data.Entity.Model;

namespace Business.Mapper.Albums
{
    public class AlbumMapper
    {
        /// <summary>
		/// Transforms CreateAlbumDTO into entity
		/// </summary>
		/// <param name="createAlbumDTO"></param>
		/// <returns></returns>
		public static Album TransformCreateDTOToEntity(CreateAlbumDTO createAlbumDTO)
        {
            return new Album()
            {
                AlbumTitle = createAlbumDTO.AlbumTitle,
                AlbumPrice = createAlbumDTO.AlbumPrice,
                AlbumQuantity = createAlbumDTO.AlbumQuantity,
                AlbumImage = createAlbumDTO.AlbumImage,
                AlbumReleaseDate = createAlbumDTO.AlbumReleaseDate,
            };
        }

        /// <summary>
        /// Transforms entity into ReadAlbumDTO
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        public static ReadAlbumDTO TransformEntityToReadAlbumDTO(Album album)
        {
            var readAlbumDTO = new ReadAlbumDTO()
            {
                AlbumId = album.AlbumId,
                AlbumTitle = album.AlbumTitle,
                AlbumPrice = album.AlbumPrice,
                AlbumQuantity = album.AlbumQuantity,
                AlbumImage = album.AlbumImage,
                AlbumReleaseDate = album.AlbumReleaseDate,
            };

            return readAlbumDTO;
        }


        /// <summary>
        /// From `Album` and `UpdateAlbum` objects, updates properties for Album
        /// </summary>
        /// <param name="album"></param>
        /// <param name="updateAlbum"></param>
        public static CreateAlbumDTO UpdateEntityFromUpdateDTO(Album album, UpdateAlbumDTO updateAlbum)
        {
            album.AlbumTitle = updateAlbum.AlbumTitle;
            album.AlbumPrice = updateAlbum.AlbumPrice;
            album.AlbumQuantity = updateAlbum.AlbumQuantity;
            album.AlbumImage = updateAlbum.AlbumImage;
            album.AlbumReleaseDate = updateAlbum.AlbumReleaseDate;

            return new CreateAlbumDTO();
        }
    }
}
