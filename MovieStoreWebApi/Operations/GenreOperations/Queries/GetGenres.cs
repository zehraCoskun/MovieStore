using AutoMapper;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Operations.GenreOperations.Queries
{
    public class GetGenres
    {
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;

        public GetGenres(IMovieStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GenresViewModel> Handle()
        {
            var genreList = _context.Genres.Where(x=> x.IsActive==true).OrderBy(x=> x.ID).ToList();
            List<GenresViewModel> vm = _mapper.Map<List<GenresViewModel>>(genreList);
            return vm;
        }
    }

    public class GenresViewModel
    {
        public string? GenreName { get; set; }
        public bool IsActive { get; set; }
    }
}