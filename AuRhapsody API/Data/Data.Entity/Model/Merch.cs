namespace Data.Entity.Model;

public partial class Merch
{
    public int MerchId { get; set; }

    public string? MerchType { get; set; }

    public string MerchName { get; set; } = null!;

    public DateOnly? MerchDate { get; set; }

    public decimal MerchPrice { get; set; }

    public int MerchQuantity { get; set; }

    public string MerchImage { get; set; } = null!;

    public virtual ICollection<Artist> Artists { get; set; } = new List<Artist>();

    public virtual ICollection<Band> Bands { get; set; } = new List<Band>();
}
