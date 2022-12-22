using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Entites;

namespace MovieStoreWebApi.DBOperations
{
    public interface IMovieStoreDBContext
    {
        DbSet<Movie> Movies { get; set; }
        DbSet<Actor> Actors { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Director> Directors { get; set; }
        DbSet<Genre> Genres { get; set; }
        int SaveChanges();
        
    }
}