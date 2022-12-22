using AutoMapper;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Operations.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovie
    {
        public int id{get;set;}
        private readonly IMovieStoreDBContext _context;

        public DeleteMovie(IMovieStoreDBContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x=> x.ID==id);
            if(movie is null)
            {throw new InvalidOperationException("Bu id'ye kayıtlı bir film yok");}

            _context.Movies.Remove(movie);
            _context.SaveChanges();        
        }
    }
}