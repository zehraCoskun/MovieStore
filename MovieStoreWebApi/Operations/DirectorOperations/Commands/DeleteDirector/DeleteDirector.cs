using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Operations.DirectorOperations.Commands
{
    public class DeleteDirector
    {
        private readonly IMovieStoreDBContext _context;
        public int id { get; set; }

        public DeleteDirector(IMovieStoreDBContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(x=> x.ID==id);
            if( director is null)
            {throw new InvalidOperationException("bu id'ye kayıtlı bir yönetmen yok");}
            _context.Directors.Remove(director);
            _context.SaveChanges();
        }
    }
}