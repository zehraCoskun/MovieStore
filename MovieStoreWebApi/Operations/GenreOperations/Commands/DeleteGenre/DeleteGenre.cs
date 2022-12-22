using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Operations.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenre
    {
        private readonly IMovieStoreDBContext _context;
        public int id { get; set; }

        public DeleteGenre(IMovieStoreDBContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.Where(x=>x.ID==id).SingleOrDefault();
            if(genre is null)
            {throw new InvalidOperationException("Bu id'ye ait bir kategori mevcut değil");}
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}