using Data.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Data.Entity
{
    public partial class ProductInspectionContext : DbContext
    {
        public ProductInspectionContext()   {}

        public ProductInspectionContext(DbContextOptions<ProductInspectionContext> options)
            : base(options)     {}

        public virtual DbSet<Factload> Factloads { get; set; }
        public virtual DbSet<Factsource> Factsources { get; set; }
        public virtual DbSet<Lproduct> Lproducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseConfigurationManager.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Factload>(entity =>
            {
                entity.HasKey(e => e.Idfactload);

                entity.ToTable("FACTLOAD");

                entity.Property(e => e.Idfactload).HasColumnName("IDFACTLOAD");

                entity.Property(e => e.Dateload)
                    .HasColumnType("datetime")
                    .HasColumnName("DATELOAD");

                entity.Property(e => e.Datetimefixed)
                    .HasColumnType("date")
                    .HasColumnName("DATETIMEFIXED");
            });

            modelBuilder.Entity<Factsource>(entity =>
            {
                entity.HasKey(e => e.Idfactsource);

                entity.ToTable("FACTSOURCE");

                entity.Property(e => e.Idfactsource).HasColumnName("IDFACTSOURCE");

                entity.Property(e => e.Idfactload).HasColumnName("IDFACTLOAD");

                entity.Property(e => e.Ksssprod).HasColumnName("KSSSPROD");

                entity.Property(e => e.Ksssunit).HasColumnName("KSSSUNIT");

                entity.Property(e => e.Vreceipt)
                    .HasColumnType("decimal(18, 3)")
                    .HasColumnName("VRECEIPT");

                entity.HasOne(d => d.IdfactloadNavigation)
                    .WithMany(p => p.Factsources)
                    .HasForeignKey(d => d.Idfactload)
                    .HasConstraintName("FK_FACTSOURCE_FACTLOAD");

                entity.HasOne(d => d.KsssprodNavigation)
                    .WithMany(p => p.Factsources)
                    .HasForeignKey(d => d.Ksssprod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FACTSOURCE_LPRODUCT");
            });

            modelBuilder.Entity<Lproduct>(entity =>
            {
                entity.HasKey(e => e.Ksssprod)
                    .HasName("PK_PRODUCT");

                entity.ToTable("LPRODUCT");

                entity.Property(e => e.Ksssprod)
                    .ValueGeneratedNever()
                    .HasColumnName("KSSSPROD")
                    .HasComment("Справочник продуктов в кодах КССС");

                entity.Property(e => e.Dupdate)
                    .HasColumnType("datetime")
                    .HasColumnName("DUPDATE");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(500)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Gost)
                    .HasMaxLength(100)
                    .HasColumnName("GOST")
                    .IsFixedLength();

                entity.Property(e => e.Idproductgroup).HasColumnName("IDPRODUCTGROUP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("NAME");

                entity.Property(e => e.Okp)
                    .HasMaxLength(10)
                    .HasColumnName("OKP")
                    .IsFixedLength();

                entity.Property(e => e.Ordernumber).HasColumnName("ORDERNUMBER");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
