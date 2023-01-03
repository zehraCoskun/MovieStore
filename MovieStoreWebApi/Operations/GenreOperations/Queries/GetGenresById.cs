using AutoMapper;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Operations.GenreOperations.Queries
{
    public class GetGenresById
    {
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;
        public int id { get; set; }

        public GetGenresById(IMovieStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetGenreByIdModel Handle()
        {
            var genre = _context.Genres.Where(x => x.ID == id).SingleOrDefault();
            if (genre is null)
            { throw new InvalidOperationException("Bu id'ye ait bir kategori mevcut değil"); }

            GetGenreByIdModel vm = _mapper.Map<GetGenreByIdModel>(genre);
            return vm;
        }
    }

    public class GetGenreByIdModel
    {
        public string? GenreName { get; set; }
        public bool IsActive { get; set; }
    }
}