using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entites;

namespace MovieStoreWebApi.Operations.MovieOperations.Commands.CreateMovie
{
    public class CreateMovie
    {
        public CreateMovieModel Model { get; set; }
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;
        public CreateMovie(IMovieStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x => x.MovieTitle == Model.MovieTitle);
            if (movie is not null)
            { throw new InvalidOperationException("Bu isme sahip bir film zaten mevcut"); }
            movie = _mapper.Map<Movie>(movie);
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
    }

    public class CreateMovieModel
    {
        public string? MovieTitle { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float Price { get; set; }
        public int GenreID { get; set; }
        public int DirectorID { get; set; }
        public int ActorID { get; set; }
    }
}