namespace Business.DTO.Albums
{
    public class CreateAlbumDTO
    {
        public string AlbumTitle { get; set; } = null!;

        public decimal AlbumPrice { get; set; }

        public int AlbumQuantity { get; set; }

        public string AlbumImage { get; set; } = null!;

        public DateOnly? AlbumReleaseDate { get; set; }
    }
}
