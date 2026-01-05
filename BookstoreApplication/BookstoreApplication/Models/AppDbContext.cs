using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<AuthorAward> AuthorAwards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorAward>(entity =>
            {
                entity.ToTable("AuthorAwardBridge");
                
            });

            modelBuilder.Entity<AuthorAward>()
                .HasOne(a => a.Author)
                .WithMany(aa => aa.AuthorAwards)
                .HasForeignKey(a => a.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AuthorAward>()
               .HasOne(a => a.Award)
               .WithMany(aa => aa.AuthorAwards)
               .HasForeignKey(a => a.AwardId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(k => k.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Author>(enetity =>
            {
                enetity.Property(a => a.DateOfBirth).HasColumnName("Birthday");
            });
        }
    }
}
