using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entites;

namespace MovieStoreWebApi.Operations.Queries
{
    public class GetMovies
    {
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;

        public GetMovies(IMovieStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<MoviesViewModel> Handle()
        {
            var movieList = _context.Movies.Include(x => x.GenreName).Include(x => x.DirectorName).Include(x => x.Actors).OrderBy(x => x.ID).ToList();
            List<MoviesViewModel> vm = _mapper.Map<List<MoviesViewModel>>(movieList);
            return vm;
        }
    }

    public class MoviesViewModel
    {
        public string? MovieTitle { get; set; }
        public string? ReleaseDate { get; set; }
        public float Price { get; set; }
        public string? Genre { get; set; }
        public string? Director { get; set; }
        public ICollection<string>? Actors { get; set; }
    }
}