using Microsoft.EntityFrameworkCore;
using System;
using TecH3DemoProject.Api.Domain;

namespace TecH3DemoProject.Api.Database
{
    public class TecH3DemoContext : DbContext
    {

        public TecH3DemoContext() { }
        public TecH3DemoContext(DbContextOptions<TecH3DemoContext> options) : base(options) { }

        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    Id = 1,
                    FirstName = "Albert",
                    LastName = "Andersen",
                    createdAt = DateTime.Now
                },
                new Author
                {
                    Id = 2,
                    FirstName = "Benjamin",
                    LastName = "Billiard",
                    createdAt = DateTime.Now
                });

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    AuthorId = 1,
                    Title = "All The Books",
                    Pages = 123,
                    Publised = DateTime.Parse("2020-02-02"),
                    createdAt = DateTime.Now
                },
                new Book
                {
                    Id = 2,
                    AuthorId = 2,
                    Title = "Books are fun",
                    Pages = 321,
                    Publised = DateTime.Parse("2021-12-21"),
                    createdAt = DateTime.Now
                },
                new Book
                {
                    Id = 3,
                    AuthorId = 1,
                    Title = "Alphabet",
                    Pages = 32,
                    Publised = DateTime.Parse("2021-03-03"),
                    createdAt = DateTime.Now
                },
                new Book
                {
                    Id = 4,
                    AuthorId = 2,
                    Title = "Bingo Bullshot",
                    Pages = 91,
                    Publised = DateTime.Parse("1993-12-22"),
                    createdAt = DateTime.Now
                });

        }

    }


}
