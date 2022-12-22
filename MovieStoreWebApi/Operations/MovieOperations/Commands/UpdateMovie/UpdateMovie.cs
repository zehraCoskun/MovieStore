using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entites;

namespace MovieStoreWebApi.Operations.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovie
    {
        private readonly IMovieStoreDBContext _context;
        public int id { get; set; }
        public UpdateMovieModel Model { get; set; }

        public UpdateMovie(IMovieStoreDBContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var movie = _context.Movies.Include(x=> x.Actors).SingleOrDefault(x => x.ID == id);
            if (movie is null)
            { throw new InvalidOperationException("Bu id'ye kayıtlı bir film yok"); }
            movie.DirectorID = Model.DirectorID != default ? movie.DirectorID : Model.DirectorID;
            movie.GenreID = Model.GenreID != default ? movie.GenreID : Model.DirectorID;
            movie.Price = Model.Price != default ? movie.Price : Model.Price;
            movie.MovieTitle = Model.MovieTitle != default ? movie.MovieTitle : Model.MovieTitle;
            movie.ReleaseDate = Model.ReleaseDate != default ? movie.ReleaseDate : Model.ReleaseDate;
            movie.Actors.Clear();
            movie.Actors = _context.Actors.Where(x => Model.Actors.Contains(x.ID)).ToList();
            _context.SaveChanges();
        }
    }

    public class UpdateMovieModel
    {
        public string? MovieTitle { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float Price { get; set; }
        public int GenreID { get; set; }
        public int DirectorID { get; set; }
        public IEnumerable<int>? Actors { get; set; }
    }
}