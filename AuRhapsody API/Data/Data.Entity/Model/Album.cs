namespace Data.Entity.Model;

public partial class Album
{
    public int AlbumId { get; set; }

    public string AlbumTitle { get; set; } = null!;

    public decimal AlbumPrice { get; set; }

    public int AlbumQuantity { get; set; }

    public string AlbumImage { get; set; } = null!;

    public DateOnly? AlbumReleaseDate { get; set; }

    public virtual ICollection<Artist> Artists { get; set; } = new List<Artist>();

    public virtual ICollection<Band> Bands { get; set; } = new List<Band>();
}
