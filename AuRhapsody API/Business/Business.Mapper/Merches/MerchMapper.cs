using Business.DTO.Merches;
using Data.Entity.Model;

namespace Business.Mapper.Merches
{
    public class MerchMapper
    {
        /// <summary>
		/// Transforms CreateMerchDTO into entity
		/// </summary>
		/// <param name="createMerchDTO"></param>
		/// <returns></returns>
		public static Merch TransformCreateDTOToEntity(CreateMerchDTO createMerchDTO)
        {
            return new Merch()
            {
                MerchType = createMerchDTO.MerchType,
                MerchName = createMerchDTO.MerchName,
                MerchDate = createMerchDTO.MerchDate,
                MerchPrice = createMerchDTO.MerchPrice,
                MerchQuantity = createMerchDTO.MerchQuantity,
                MerchImage = createMerchDTO.MerchImage,
            };
        }

        /// <summary>
        /// Transforms entity into ReadMerchDTO
        /// </summary>
        /// <param name="merch"></param>
        /// <returns></returns>
        public static ReadMerchDTO TransformEntityToReadMerchDTO(Merch merch)
        {
            var readMerchDTO = new ReadMerchDTO()
            {
                MerchType = merch.MerchType,
                MerchName = merch.MerchName,
                MerchDate = merch.MerchDate,
                MerchPrice = merch.MerchPrice,
                MerchQuantity = merch.MerchQuantity,
                MerchImage = merch.MerchImage,
            };

            return readMerchDTO;
        }


        /// <summary>
        /// From `Merch` and `UpdateMerch` objects, updates properties for Merch
        /// </summary>
        /// <param name="merch"></param>
        /// <param name="updateMerch"></param>
        public static CreateMerchDTO UpdateEntityFromUpdateDTO(Merch merch, UpdateMerchDTO updateMerch)
        {
            merch.MerchType = updateMerch.MerchType;
            merch.MerchName = updateMerch.MerchName;
            merch.MerchDate = updateMerch.MerchDate;
            merch.MerchPrice = updateMerch.MerchPrice;
            merch.MerchQuantity = updateMerch.MerchQuantity;
            merch.MerchImage = updateMerch.MerchImage;

            return new CreateMerchDTO();
        }
    }
}
