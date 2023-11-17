namespace Data.Entity.Model;

public partial class Single
{
    public int SingleId { get; set; }

    public string SingleTitle { get; set; } = null!;

    public decimal SinglePrice { get; set; }

    public int SingleQuantity { get; set; }

    public string SingleImage { get; set; } = null!;

    public DateOnly? SingleReleaseDate { get; set; }

    public virtual ICollection<Artist> Artists { get; set; } = new List<Artist>();

    public virtual ICollection<Band> Bands { get; set; } = new List<Band>();
}
