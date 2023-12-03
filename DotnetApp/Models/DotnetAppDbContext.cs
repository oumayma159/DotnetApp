using Microsoft.EntityFrameworkCore;

namespace DotnetApp.Models
{
    public class DotnetAppDbContext : DbContext
    {
        public DotnetAppDbContext(DbContextOptions options)
       : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Membershiptype> Membershiptypes { get; set; }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            string genresJson = File.ReadAllText("data/Genre.json");
            List<Genre>? genres = System.Text.Json.JsonSerializer.Deserialize<List<Genre>>(genresJson);
            if (genres == null)
            {
                return;
            }
            foreach (var genre in genres)
            {
                modelBuilder
                    .Entity<Genre>()
                    .HasData(genre);
            }


            base.OnModelCreating(modelBuilder);
            string membershiptypesJson = File.ReadAllText("data/Membershiptype.json");
            List<Membershiptype>? membershiptypes = System.Text.Json.JsonSerializer.Deserialize<List<Membershiptype>>(membershiptypesJson);

            if (membershiptypes == null)
            {
                return;
            }

            foreach (var membershiptype in membershiptypes)
            {
                modelBuilder
                    .Entity<Membershiptype>()
                    .HasData(membershiptype);
            }



        }
    }
}

