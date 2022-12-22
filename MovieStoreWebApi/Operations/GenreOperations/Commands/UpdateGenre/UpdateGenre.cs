using AutoMapper;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Operations.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenre
    {
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;
        public int id { get; set; }
        public UpdateGenreModel Model;

        public UpdateGenre(UpdateGenreModel model, IMovieStoreDBContext context, IMapper mapper)
        {
            Model = model;
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.ID == id);
            if (genre is null)
            { throw new InvalidOperationException("Bu id'ye ait bir kategori mevcut değil"); }
            if (_context.Genres.Any(x => x.GenreName.ToLower() == Model.GenreName.ToLower() && x.ID != genre.ID))
            { throw new InvalidOperationException("Bu isimde bir film türü zaten mevcut"); }
            genre.GenreName = string.IsNullOrEmpty(Model.GenreName.Trim()) != default ? genre.GenreName : Model.GenreName;
            genre.IsActive=Model.IsActive;
            _context.SaveChanges();
        }
    }

    public class UpdateGenreModel
    {
        public string? GenreName { get; set; }
        public bool IsActive { get; set; }
    }
}