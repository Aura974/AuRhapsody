namespace Business.DTO.Singles
{
    public class CreateSingleDTO
    {
        public string SingleTitle { get; set; } = null!;

        public decimal SinglePrice { get; set; }

        public int SingleQuantity { get; set; }

        public string SingleImage { get; set; } = null!;

        public DateOnly? SingleReleaseDate { get; set; }
    }
}
