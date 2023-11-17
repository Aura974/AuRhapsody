using Business.DTO.Artists;
using Data.Entity.Model;

namespace Business.Mapper.Artists
{
    public class ArtistMapper
    {
        /// <summary>
		/// Transforms CreateArtistDTO into entity
		/// </summary>
		/// <param name="createArtistDTO"></param>
		/// <returns></returns>
		public static Artist TransformCreateDTOToEntity(CreateArtistDTO createArtistDTO)
        {
            return new Artist()
            {
                ArtistName = createArtistDTO.ArtistName,
                DateOfBirth = createArtistDTO.DateOfBirth,
                ArtistBiography = createArtistDTO.ArtistBiography,
                ArtistWebsite = createArtistDTO.ArtistWebsite,
                ArtistImage = createArtistDTO.ArtistImage,
                ArtistActive = createArtistDTO.ArtistActive,
            };
        }

        /// <summary>
        /// Transforms entity into ReadArtistDTO
        /// </summary>
        /// <param name="artist"></param>
        /// <returns></returns>
        public static ReadArtistDTO TransformEntityToReadArtistDTO(Artist artist)
        {
            var readArtistDTO = new ReadArtistDTO()
            {
                ArtistName = artist.ArtistName,
                DateOfBirth = artist.DateOfBirth,
                ArtistBiography = artist.ArtistBiography,
                ArtistWebsite = artist.ArtistWebsite,
                ArtistImage = artist.ArtistImage,
            };

            return readArtistDTO;
        }


        /// <summary>
        /// From `Artist` and `UpdateArtist` objects, updates properties for Artist
        /// </summary>
        /// <param name="artist"></param>
        /// <param name="updateArtist"></param>
        public static CreateArtistDTO UpdateEntityFromUpdateDTO(Artist artist, UpdateArtistDTO updateArtist)
        {
            artist.ArtistName = updateArtist.ArtistName;
            artist.DateOfBirth = updateArtist.DateOfBirth;
            artist.ArtistBiography = updateArtist.ArtistBiography;
            artist.ArtistWebsite = updateArtist.ArtistWebsite;
            artist.ArtistImage = updateArtist.ArtistImage;
            artist.ArtistActive = updateArtist.ArtistActive;

            return new CreateArtistDTO();
        }
    }
}
