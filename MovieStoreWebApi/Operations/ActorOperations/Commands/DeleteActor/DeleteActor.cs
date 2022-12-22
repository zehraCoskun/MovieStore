using MovieStoreWebApi.DBOperations;
namespace MovieStoreWebApi.Operations.ActorOperations.Commands.DeleteActor
{
    public class DeleteActor
    {
        private readonly IMovieStoreDBContext _context;
        public int id{get;set;}
        public DeleteActor(IMovieStoreDBContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x=> x.ID==id);
            if(actor is null)
            {throw new InvalidOperationException("Bu isme sahip bir oyuncu mevcut değil");}
            _context.Actors.Remove(actor);
            _context.SaveChanges();
        }


    }
}