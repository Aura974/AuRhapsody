using Business.DTO.Bands;
using Data.Entity.Model;

namespace Business.Mapper.Bands
{
    public class BandMapper
    {
        /// <summary>
		/// Transforms CreateBandDTO into entity
		/// </summary>
		/// <param name="createBandDTO"></param>
		/// <returns></returns>
		public static Band TransformCreateDTOToEntity(CreateBandDTO createBandDTO)
        {
            return new Band()
            {
                BandName = createBandDTO.BandName,
                DateOfCreation = createBandDTO.DateOfCreation,
                BandBiography = createBandDTO.BandBiography,
                BandWebsite = createBandDTO.BandWebsite,
                BandImage = createBandDTO.BandImage,
                BandActive = createBandDTO.BandActive,
            };
        }

        /// <summary>
        /// Transforms entity into ReadBandDTO
        /// </summary>
        /// <param name="band"></param>
        /// <returns></returns>
        public static ReadBandDTO TransformEntityToReadBandDTO(Band band)
        {
            var readBandDTO = new ReadBandDTO()
            {
                BandName = band.BandName,
                DateOfCreation = band.DateOfCreation,
                BandBiography = band.BandBiography,
                BandWebsite = band.BandWebsite,
                BandImage = band.BandImage,
            };

            return readBandDTO;
        }


        /// <summary>
        /// From `Band` and `UpdateBand` objects, updates properties for Band
        /// </summary>
        /// <param name="band"></param>
        /// <param name="updateBand"></param>
        public static CreateBandDTO UpdateEntityFromUpdateDTO(Band band, UpdateBandDTO updateBand)
        {
            band.BandName = updateBand.BandName;
            band.DateOfCreation = updateBand.DateOfCreation;
            band.BandBiography = updateBand.BandBiography;
            band.BandWebsite = updateBand.BandWebsite;
            band.BandImage = updateBand.BandImage;
            band.BandActive = updateBand.BandActive;

            return new CreateBandDTO();
        }
    }
}
