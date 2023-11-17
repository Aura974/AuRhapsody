using Data.Context.Contract;
using Data.Entity.Model;
using Microsoft.EntityFrameworkCore;
using Single = Data.Entity.Model.Single;

namespace Data.Entity;

public partial class AuRhapsodyDBContext : DbContext, IAuRhapsodyDBContext
{
    public AuRhapsodyDBContext()
    {
    }

    public AuRhapsodyDBContext(DbContextOptions<AuRhapsodyDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Band> Bands { get; set; }

    public virtual DbSet<Merch> Merches { get; set; }

    public virtual DbSet<Single> Singles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("server=localhost;user=Aura;password=1234;database=aurhapsody;port=3306", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Album>(entity =>
        {
            entity.HasKey(e => e.AlbumId).HasName("PRIMARY");

            entity.ToTable("album");

            entity.Property(e => e.AlbumId).HasColumnName("AlbumID");
            entity.Property(e => e.AlbumImage).HasMaxLength(150);
            entity.Property(e => e.AlbumPrice).HasPrecision(6, 2);
            entity.Property(e => e.AlbumTitle).HasMaxLength(50);

            entity.HasMany(d => d.Bands).WithMany(p => p.Albums)
                .UsingEntity<Dictionary<string, object>>(
                    "Bandalbum",
                    r => r.HasOne<Band>().WithMany()
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("bandalbum_ibfk_2"),
                    l => l.HasOne<Album>().WithMany()
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("bandalbum_ibfk_1"),
                    j =>
                    {
                        j.HasKey("AlbumId", "BandId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("bandalbum");
                        j.HasIndex(new[] { "BandId" }, "BandID");
                        j.IndexerProperty<int>("AlbumId").HasColumnName("AlbumID");
                        j.IndexerProperty<int>("BandId").HasColumnName("BandID");
                    });
        });

        modelBuilder.Entity<Artist>(entity =>
        {
            entity.HasKey(e => e.ArtistId).HasName("PRIMARY");

            entity.ToTable("artist");

            entity.Property(e => e.ArtistId).HasColumnName("ArtistID");
            entity.Property(e => e.ArtistActive).HasDefaultValueSql("'1'");
            entity.Property(e => e.ArtistBiography).HasColumnType("text");
            entity.Property(e => e.ArtistImage).HasMaxLength(150);
            entity.Property(e => e.ArtistName).HasMaxLength(50);
            entity.Property(e => e.ArtistWebsite).HasMaxLength(100);

            entity.HasMany(d => d.Albums).WithMany(p => p.Artists)
                .UsingEntity<Dictionary<string, object>>(
                    "Artistalbum",
                    r => r.HasOne<Album>().WithMany()
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("artistalbum_ibfk_2"),
                    l => l.HasOne<Artist>().WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("artistalbum_ibfk_1"),
                    j =>
                    {
                        j.HasKey("ArtistId", "AlbumId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("artistalbum");
                        j.HasIndex(new[] { "AlbumId" }, "AlbumID");
                        j.IndexerProperty<int>("ArtistId").HasColumnName("ArtistID");
                        j.IndexerProperty<int>("AlbumId").HasColumnName("AlbumID");
                    });

            entity.HasMany(d => d.Bands).WithMany(p => p.Artists)
                .UsingEntity<Dictionary<string, object>>(
                    "Member",
                    r => r.HasOne<Band>().WithMany()
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("members_ibfk_2"),
                    l => l.HasOne<Artist>().WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("members_ibfk_1"),
                    j =>
                    {
                        j.HasKey("ArtistId", "BandId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("members");
                        j.HasIndex(new[] { "BandId" }, "BandID");
                        j.IndexerProperty<int>("ArtistId").HasColumnName("ArtistID");
                        j.IndexerProperty<int>("BandId").HasColumnName("BandID");
                    });

            entity.HasMany(d => d.Merches).WithMany(p => p.Artists)
                .UsingEntity<Dictionary<string, object>>(
                    "Artistmerch",
                    r => r.HasOne<Merch>().WithMany()
                        .HasForeignKey("MerchId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("artistmerch_ibfk_2"),
                    l => l.HasOne<Artist>().WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("artistmerch_ibfk_1"),
                    j =>
                    {
                        j.HasKey("ArtistId", "MerchId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("artistmerch");
                        j.HasIndex(new[] { "MerchId" }, "MerchID");
                        j.IndexerProperty<int>("ArtistId").HasColumnName("ArtistID");
                        j.IndexerProperty<int>("MerchId").HasColumnName("MerchID");
                    });

            entity.HasMany(d => d.Singles).WithMany(p => p.Artists)
                .UsingEntity<Dictionary<string, object>>(
                    "Artistsingle",
                    r => r.HasOne<Single>().WithMany()
                        .HasForeignKey("SingleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("artistsingle_ibfk_2"),
                    l => l.HasOne<Artist>().WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("artistsingle_ibfk_1"),
                    j =>
                    {
                        j.HasKey("ArtistId", "SingleId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("artistsingle");
                        j.HasIndex(new[] { "SingleId" }, "SingleID");
                        j.IndexerProperty<int>("ArtistId").HasColumnName("ArtistID");
                        j.IndexerProperty<int>("SingleId").HasColumnName("SingleID");
                    });
        });

        modelBuilder.Entity<Band>(entity =>
        {
            entity.HasKey(e => e.BandId).HasName("PRIMARY");

            entity.ToTable("band");

            entity.Property(e => e.BandId).HasColumnName("BandID");
            entity.Property(e => e.BandActive).HasDefaultValueSql("'1'");
            entity.Property(e => e.BandBiography).HasColumnType("text");
            entity.Property(e => e.BandImage).HasMaxLength(150);
            entity.Property(e => e.BandName).HasMaxLength(50);
            entity.Property(e => e.BandWebsite).HasMaxLength(100);

            entity.HasMany(d => d.Merches).WithMany(p => p.Bands)
                .UsingEntity<Dictionary<string, object>>(
                    "Bandmerch",
                    r => r.HasOne<Merch>().WithMany()
                        .HasForeignKey("MerchId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("bandmerch_ibfk_2"),
                    l => l.HasOne<Band>().WithMany()
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("bandmerch_ibfk_1"),
                    j =>
                    {
                        j.HasKey("BandId", "MerchId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("bandmerch");
                        j.HasIndex(new[] { "MerchId" }, "MerchID");
                        j.IndexerProperty<int>("BandId").HasColumnName("BandID");
                        j.IndexerProperty<int>("MerchId").HasColumnName("MerchID");
                    });

            entity.HasMany(d => d.Singles).WithMany(p => p.Bands)
                .UsingEntity<Dictionary<string, object>>(
                    "Bandsingle",
                    r => r.HasOne<Single>().WithMany()
                        .HasForeignKey("SingleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("bandsingle_ibfk_2"),
                    l => l.HasOne<Band>().WithMany()
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("bandsingle_ibfk_1"),
                    j =>
                    {
                        j.HasKey("BandId", "SingleId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("bandsingle");
                        j.HasIndex(new[] { "SingleId" }, "SingleID");
                        j.IndexerProperty<int>("BandId").HasColumnName("BandID");
                        j.IndexerProperty<int>("SingleId").HasColumnName("SingleID");
                    });
        });

        modelBuilder.Entity<Merch>(entity =>
        {
            entity.HasKey(e => e.MerchId).HasName("PRIMARY");

            entity.ToTable("merch");

            entity.Property(e => e.MerchId).HasColumnName("MerchID");
            entity.Property(e => e.MerchImage).HasMaxLength(150);
            entity.Property(e => e.MerchName).HasMaxLength(50);
            entity.Property(e => e.MerchPrice).HasPrecision(6, 2);
            entity.Property(e => e.MerchType).HasMaxLength(50);
        });

        modelBuilder.Entity<Single>(entity =>
        {
            entity.HasKey(e => e.SingleId).HasName("PRIMARY");

            entity.ToTable("single");

            entity.Property(e => e.SingleId).HasColumnName("SingleID");
            entity.Property(e => e.SingleImage).HasMaxLength(150);
            entity.Property(e => e.SinglePrice).HasPrecision(6, 2);
            entity.Property(e => e.SingleTitle).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
