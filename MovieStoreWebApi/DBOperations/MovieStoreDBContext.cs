using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Entites;

namespace MovieStoreWebApi.DBOperations
{
    public class MovieStoreDBContext : DbContext, IMovieStoreDBContext
    {
        public MovieStoreDBContext(DbContextOptions <MovieStoreDBContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}