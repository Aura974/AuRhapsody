namespace Business.DTO.Merches
{
    public class CreateMerchDTO
    {
        public string? MerchType { get; set; }

        public string MerchName { get; set; } = null!;

        public DateOnly? MerchDate { get; set; }

        public decimal MerchPrice { get; set; }

        public int MerchQuantity { get; set; }

        public string MerchImage { get; set; } = null!;
    }
}
