namespace Data.Entity.Model;

public partial class Artist
{
    public int ArtistId { get; set; }

    public string ArtistName { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public string? ArtistBiography { get; set; }

    public string? ArtistWebsite { get; set; }

    public string ArtistImage { get; set; } = null!;

    public bool? ArtistActive { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();

    public virtual ICollection<Band> Bands { get; set; } = new List<Band>();

    public virtual ICollection<Merch> Merches { get; set; } = new List<Merch>();

    public virtual ICollection<Single> Singles { get; set; } = new List<Single>();
}
