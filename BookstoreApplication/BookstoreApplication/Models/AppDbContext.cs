using Microsoft.EntityFrameworkCore;
using System;

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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthorAward>(entity =>
            {
                entity.ToTable("AuthorAwardBridge");
                entity.HasOne(a => a.Author)
                      .WithMany(aa => aa.AuthorAwards)
                      .HasForeignKey(a => a.AuthorId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(a => a.Award)
                      .WithMany(aa => aa.AuthorAwards)
                      .HasForeignKey(a => a.AwardId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(k => k.PublisherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Author>()
                .Property(a => a.DateOfBirth)
                .HasColumnName("Birthday")
                .HasColumnType("timestamp without time zone");

            modelBuilder.Entity<Book>()
                .Property(b => b.PublishedDate)
                .HasColumnType("timestamp without time zone");

            // TESTNI PODACI

            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FullName = "J.K. Rowling", Biography = "British author", DateOfBirth = new DateTime(1965, 7, 31) },
                new Author { Id = 2, FullName = "George R.R. Martin", Biography = "American novelist", DateOfBirth = new DateTime(1948, 9, 20) },
                new Author { Id = 3, FullName = "Agatha Christie", Biography = "English writer", DateOfBirth = new DateTime(1890, 9, 15) },
                new Author { Id = 4, FullName = "J.R.R. Tolkien", Biography = "British writer", DateOfBirth = new DateTime(1892, 1, 3) },
                new Author { Id = 5, FullName = "Stephen King", Biography = "American author", DateOfBirth = new DateTime(1947, 9, 21) }
            );

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Id = 1, Name = "Penguin Books", Address = "London", Website = "www.penguin.com" },
                new Publisher { Id = 2, Name = "HarperCollins", Address = "New York", Website = "www.harpercollins.com" },
                new Publisher { Id = 3, Name = "Random House", Address = "New York", Website = "www.randomhouse.com" }
            );

            modelBuilder.Entity<Award>().HasData(
                new Award { Id = 1, Name = "Best Fiction", Description = "Top fiction award", Year = 2000 },
                new Award { Id = 2, Name = "Reader's Choice", Description = "Voted by readers", Year = 2005 },
                new Award { Id = 3, Name = "Lifetime Achievement", Description = "Lifetime award", Year = 2010 },
                new Award { Id = 4, Name = "Best Novel", Description = "Award for best novel", Year = 2020 }
            );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Harry Potter 1", AuthorId = 1, PublisherId = 1, ISBN = "9780747532699", PageCount = 320, PublishedDate = new DateTime(1997, 6, 26) },
                new Book { Id = 2, Title = "Harry Potter 2", AuthorId = 1, PublisherId = 1, ISBN = "9780747538493", PageCount = 341, PublishedDate = new DateTime(1998, 7, 2) },
                new Book { Id = 3, Title = "A Game of Thrones", AuthorId = 2, PublisherId = 2, ISBN = "9780553103540", PageCount = 694, PublishedDate = new DateTime(1996, 8, 6) },
                new Book { Id = 4, Title = "A Clash of Kings", AuthorId = 2, PublisherId = 2, ISBN = "9780553108033", PageCount = 768, PublishedDate = new DateTime(1998, 11, 16) },
                new Book { Id = 5, Title = "Murder on the Orient Express", AuthorId = 3, PublisherId = 3, ISBN = "9780007119318", PageCount = 256, PublishedDate = new DateTime(1934, 1, 1) },
                new Book { Id = 6, Title = "And Then There Were None", AuthorId = 3, PublisherId = 3, ISBN = "9780062073488", PageCount = 272, PublishedDate = new DateTime(1939, 11, 6) },
                new Book { Id = 7, Title = "The Hobbit", AuthorId = 4, PublisherId = 1, ISBN = "9780547928227", PageCount = 310, PublishedDate = new DateTime(1937, 9, 21) },
                new Book { Id = 8, Title = "The Lord of the Rings", AuthorId = 4, PublisherId = 1, ISBN = "9780544003415", PageCount = 1178, PublishedDate = new DateTime(1954, 7, 29) },
                new Book { Id = 9, Title = "The Shining", AuthorId = 5, PublisherId = 2, ISBN = "9780385121675", PageCount = 447, PublishedDate = new DateTime(1977, 1, 28) },
                new Book { Id = 10, Title = "It", AuthorId = 5, PublisherId = 2, ISBN = "9781501142970", PageCount = 1138, PublishedDate = new DateTime(1986, 9, 15) },
                new Book { Id = 11, Title = "Carrie", AuthorId = 5, PublisherId = 3, ISBN = "9780385086953", PageCount = 199, PublishedDate = new DateTime(1974, 4, 5) },
                new Book { Id = 12, Title = "Fantastic Beasts", AuthorId = 1, PublisherId = 3, ISBN = "9780439321600", PageCount = 128, PublishedDate = new DateTime(2001, 11, 1) }
            );

            modelBuilder.Entity<AuthorAward>().HasData(
                new AuthorAward { Id = 1, AuthorId = 1, AwardId = 1, YearAward = 2000 },
                new AuthorAward { Id = 2, AuthorId = 1, AwardId = 2, YearAward = 2005 },
                new AuthorAward { Id = 3, AuthorId = 2, AwardId = 1, YearAward = 2000 },
                new AuthorAward { Id = 4, AuthorId = 2, AwardId = 4, YearAward = 2020 },
                new AuthorAward { Id = 5, AuthorId = 3, AwardId = 3, YearAward = 2010 },
                new AuthorAward { Id = 6, AuthorId = 3, AwardId = 2, YearAward = 2005 },
                new AuthorAward { Id = 7, AuthorId = 4, AwardId = 4, YearAward = 2020 },
                new AuthorAward { Id = 8, AuthorId = 4, AwardId = 1, YearAward = 2000 },
                new AuthorAward { Id = 9, AuthorId = 5, AwardId = 2, YearAward = 2005 },
                new AuthorAward { Id = 10, AuthorId = 5, AwardId = 4, YearAward = 2020 },
                new AuthorAward { Id = 11, AuthorId = 1, AwardId = 4, YearAward = 2020 },
                new AuthorAward { Id = 12, AuthorId = 2, AwardId = 2, YearAward = 2005 },
                new AuthorAward { Id = 13, AuthorId = 3, AwardId = 1, YearAward = 2000 },
                new AuthorAward { Id = 14, AuthorId = 4, AwardId = 2, YearAward = 2005 },
                new AuthorAward { Id = 15, AuthorId = 5, AwardId = 3, YearAward = 2010 }
            );
        }
    }
}
