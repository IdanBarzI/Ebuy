using Microsoft.EntityFrameworkCore;
using Models;

namespace sqlExperiment
{
    public partial class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Bogo> Bogos { get; set; } = null!;
        public virtual DbSet<CasualCustomer> CasualCustomers { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<ClubMember> ClubMembers { get; set; } = null!;
        public virtual DbSet<CountriesArea> CountriesAreas { get; set; } = null!;
        public virtual DbSet<CreditCardType> CreditCardTypes { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<DeliveryMode> DeliveryModes { get; set; } = null!;
        public virtual DbSet<Discount> Discounts { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<PurchasedProduct> PurchasedProducts { get; set; } = null!;
        public virtual DbSet<ShipmentAddress> ShipmentAddresses { get; set; } = null!;
        public virtual DbSet<ShipmentArea> ShipmentAreas { get; set; } = null!;
        public virtual DbSet<ShipmentCompany> ShipmentCompanies { get; set; } = null!;
        public virtual DbSet<ShipmentOption> ShipmentOptions { get; set; } = null!;
        public virtual DbSet<ShipmentPrice> ShipmentPrices { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;
        public virtual DbSet<Vat> Vats { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DONI;Database=ofe;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AuthorName).HasMaxLength(50);
            });

            modelBuilder.Entity<Bogo>(entity =>
            {
                entity.ToTable("BOGO");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Bogolevel).HasColumnName("BOGOlevel");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Bogos)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_BOGO_Products");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<ClubMember>(entity =>
            {
                //entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.Addres)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                //entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Email)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.LoginName).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.RegistrationDate).HasColumnType("date");

                //entity.HasOne(d => d.Customer)
                //    .WithMany()
                //    .HasForeignKey(d => d.CustomerId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_ClubMembers_User");
            });

            modelBuilder.Entity<CountriesArea>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.ShipmentAreaId).HasColumnName("ShipmentAreaID");

                entity.HasOne(d => d.ShipmentArea)
                    .WithMany(p => p.CountriesAreas)
                    .HasForeignKey(d => d.ShipmentAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CountriesAreas_ShipmentAreas");
            });

            modelBuilder.Entity<CreditCardType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Prefix)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            //modelBuilder.Entity<Customer>(entity =>
            //{
            //    entity.HasKey(e => e.CustomerId).HasName("ID");


            //    //entity.Property(e => e.IsClubMember)
            //    //    .HasMaxLength(10)
            //    //    .IsFixedLength();
            //});

            modelBuilder.Entity<DeliveryMode>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Keywords).HasMaxLength(50);

                entity.Property(e => e.Publishdate).HasColumnType("date");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Products_Authors");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Products_Categories");
            });

            modelBuilder.Entity<CasualCustomer>(entity =>
            {
                //entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.Addres).HasMaxLength(50);

                //entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstPurchasing).HasColumnType("date");

                entity.Property(e => e.LoginName).HasMaxLength(50);

                //entity.HasMany(d => d.PurchasedProducts)
                //    .WithMany()
                //    .HasForeignKey(d => d.CustomerId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_CasualCustomers_User");
                //entity.HasMany(d => d.PurchasedProducts)
                //.WithOne(c => c.CustomerId);

            });

            modelBuilder.Entity<PurchasedProduct>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerId");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.PurchaseDate).HasColumnType("date");

                entity.Property(e => e.TransactionId).HasColumnName("TransactionID");

                entity.Property(e => e.Vat).HasColumnName("VAT");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.PurchasedProducts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_purchasedProducts_Customers");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchasedProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_purchasedProducts_Products");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.PurchasedProducts)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_purchasedProducts_Transactions");
            });

            modelBuilder.Entity<ShipmentAddress>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Buyer).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.HouseNumber).HasMaxLength(50);

                entity.Property(e => e.Pbo)
                    .HasMaxLength(50)
                    .HasColumnName("PBO");

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(50);

                entity.Property(e => e.ZipCode).HasMaxLength(50);

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.ShipmentAddresses)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("FK_ShipmentAddresses_CountriesAreas");
            });

            modelBuilder.Entity<ShipmentArea>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Area).HasMaxLength(50);
            });

            modelBuilder.Entity<ShipmentCompany>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CompanyName).HasMaxLength(50);
            });

            modelBuilder.Entity<ShipmentOption>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<ShipmentPrice>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ShipmentAreaId).HasColumnName("ShipmentAreaID");

                entity.Property(e => e.ShipmentCompanyId).HasColumnName("ShipmentCompanyID");

                entity.Property(e => e.ShipmentOptionId).HasColumnName("ShipmentOptionID");

                entity.HasOne(d => d.ShipmentArea)
                    .WithMany(p => p.ShipmentPrices)
                    .HasForeignKey(d => d.ShipmentAreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShipmentPrices_ShipmentAreas");

                entity.HasOne(d => d.ShipmentCompany)
                    .WithMany(p => p.ShipmentPrices)
                    .HasForeignKey(d => d.ShipmentCompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShipmentPrices_ShipmentCompanies");

                entity.HasOne(d => d.ShipmentOption)
                    .WithMany(p => p.ShipmentPrices)
                    .HasForeignKey(d => d.ShipmentOptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShipmentPrices_ShipmentOptions");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CcexpireDate)
                    .HasColumnType("date")
                    .HasColumnName("CCExpireDate");

                entity.Property(e => e.Ccnumber)
                    .HasMaxLength(50)
                    .HasColumnName("CCNumber");

                entity.Property(e => e.CcownerName)
                    .HasMaxLength(50)
                    .HasColumnName("CCOwnerName");

                entity.Property(e => e.CctypeId).HasColumnName("CCTypeID");

                entity.Property(e => e.DeliveryDate).HasColumnType("date");

                entity.Property(e => e.DeliveryModeId).HasColumnName("DeliveryModeID");

                entity.Property(e => e.ShipmentAddressId).HasColumnName("ShipmentAddressID");

                entity.Property(e => e.ShipmentCompanyId).HasColumnName("ShipmentCompanyID");

                entity.Property(e => e.ShipmentOptionId).HasColumnName("ShipmentOptionID");

                entity.HasOne(d => d.Cctype)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.CctypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transactions_CreditCardTypes");

                entity.HasOne(d => d.DeliveryMode)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.DeliveryModeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transactions_DeliveryMode");

                entity.HasOne(d => d.ShipmentAddress)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.ShipmentAddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transactions_ShipmentAddresses");

                entity.HasOne(d => d.ShipmentOption)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.ShipmentOptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transactions_ShipmentOptions");
            });

            modelBuilder.Entity<Vat>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("VAT");

                entity.Property(e => e.Vat1).HasColumnName("Vat");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}