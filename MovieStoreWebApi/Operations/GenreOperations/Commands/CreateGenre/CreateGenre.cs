using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entites;

namespace MovieStoreWebApi.Operations.GenreOperations.Commands
{
    public class CreateGenre
    {
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;
        public CreateGenreModel Model;

        public CreateGenre(IMapper mapper, IMovieStoreDBContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x=> x.GenreName==Model.GenreName);
            if(genre is not null)
            {throw new InvalidOperationException("Bu tür zaten kayıtlı");}
            genre =_mapper.Map<Genre>(Model);
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }
    }

    public class CreateGenreModel
    {
        public string? GenreName { get; set; }
        public bool IsActive { get; set; }
    }
}