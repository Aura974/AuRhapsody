namespace Business.DTO.Artists
{
    public class CreateArtistDTO
    {
        public string ArtistName { get; set; } = null!;

        public DateOnly? DateOfBirth { get; set; }

        public string? ArtistBiography { get; set; }

        public string? ArtistWebsite { get; set; }

        public string ArtistImage { get; set; } = null!;

        public bool ArtistActive { get; set; }
    }
}
