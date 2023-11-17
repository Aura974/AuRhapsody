namespace Business.DTO.Bands
{
    public class CreateBandDTO
    {
        public string BandName { get; set; } = null!;

        public DateOnly? DateOfCreation { get; set; }

        public string? BandBiography { get; set; }

        public string? BandWebsite { get; set; }

        public string BandImage { get; set; } = null!;

        public bool BandActive { get; set; }
    }
}
