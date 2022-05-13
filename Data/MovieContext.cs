using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Address>()
                .HasOne(address => address.Cinema)
                .WithOne(cinema => cinema.Address)
                .HasForeignKey<Cinema>(cinema => cinema.AddressId);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
    }
}
