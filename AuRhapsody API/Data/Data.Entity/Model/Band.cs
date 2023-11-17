namespace Data.Entity.Model;

public partial class Band
{
    public int BandId { get; set; }

    public string BandName { get; set; } = null!;

    public DateOnly? DateOfCreation { get; set; }

    public string? BandBiography { get; set; }

    public string? BandWebsite { get; set; }

    public string BandImage { get; set; } = null!;

    public bool? BandActive { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();

    public virtual ICollection<Artist> Artists { get; set; } = new List<Artist>();

    public virtual ICollection<Merch> Merches { get; set; } = new List<Merch>();

    public virtual ICollection<Single> Singles { get; set; } = new List<Single>();
}
