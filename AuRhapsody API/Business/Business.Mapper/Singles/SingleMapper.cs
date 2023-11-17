using Business.DTO.Singles;
using Single = Data.Entity.Model.Single;

namespace Business.Mapper.Singles
{
    public class SingleMapper
    {
        /// <summary>
		/// Transforms CreateSingleDTO into entity
		/// </summary>
		/// <param name="createSingleDTO"></param>
		/// <returns></returns>
		public static Single TransformCreateDTOToEntity(CreateSingleDTO createSingleDTO)
        {
            return new Single()
            {
                SingleTitle = createSingleDTO.SingleTitle,
                SinglePrice = createSingleDTO.SinglePrice,
                SingleQuantity = createSingleDTO.SingleQuantity,
                SingleImage = createSingleDTO.SingleImage,
                SingleReleaseDate = createSingleDTO.SingleReleaseDate,
            };
        }

        /// <summary>
        /// Transforms entity into ReadSingleDTO
        /// </summary>
        /// <param name="single"></param>
        /// <returns></returns>
        public static ReadSingleDTO TransformEntityToReadSingleDTO(Single single)
        {
            var readSingleDTO = new ReadSingleDTO()
            {
                SingleId = single.SingleId,
                SingleTitle = single.SingleTitle,
                SinglePrice = single.SinglePrice,
                SingleQuantity = single.SingleQuantity,
                SingleImage = single.SingleImage,
                SingleReleaseDate = single.SingleReleaseDate,
            };

            return readSingleDTO;
        }


        /// <summary>
        /// From `Single` and `UpdateSingle` objects, updates properties for Single
        /// </summary>
        /// <param name="single"></param>
        /// <param name="updateSingle"></param>
        public static CreateSingleDTO UpdateEntityFromUpdateDTO(Single single, UpdateSingleDTO updateSingle)
        {
            single.SingleTitle = updateSingle.SingleTitle;
            single.SinglePrice = updateSingle.SinglePrice;
            single.SingleQuantity = updateSingle.SingleQuantity;
            single.SingleImage = updateSingle.SingleImage;
            single.SingleReleaseDate = updateSingle.SingleReleaseDate;

            return new CreateSingleDTO();
        }
    }
}
