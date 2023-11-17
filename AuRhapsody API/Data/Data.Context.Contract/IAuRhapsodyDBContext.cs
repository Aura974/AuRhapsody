using Data.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Context.Contract
{
    public interface IAuRhapsodyDBContext : IDBContext
    {
        DbSet<Album> Albums { get; set; }

        DbSet<Artist> Artists { get; set; }

        DbSet<Band> Bands { get; set; }

        DbSet<Merch> Merches { get; set; }

        DbSet<Entity.Model.Single> Singles { get; set; }
    }
}
