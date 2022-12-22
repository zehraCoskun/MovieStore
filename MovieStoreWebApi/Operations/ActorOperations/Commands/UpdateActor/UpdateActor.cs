using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Operations.ActorOperations.Commands.UpdateActor
{
    public class UpdateActor
    {
        private readonly IMovieStoreDBContext _context;
        public ActorUpdateModel Model { get; set; }
        public int id { get; set; }

        public UpdateActor(IMovieStoreDBContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var actor = _context.Actors.Include(x => x.Movies).SingleOrDefault(x => x.ID == id);
            if (actor is null)
            { throw new InvalidOperationException("Bu id'ye kayıtlı bir oyuncu mevcut değil"); }

            actor.Firstname = string.IsNullOrEmpty(Model.Firstname) != default ? actor.Firstname : Model.Firstname;
            actor.Surname = string.IsNullOrEmpty(Model.Surname) != default ? actor.Surname : Model.Surname;
            actor.Movies.Clear();

            actor.Movies = _context.Movies.Where(x=> Model.Movies.Contains(x.ID)).ToList();
                
            _context.SaveChanges();
        }
    }

    public class ActorUpdateModel
    {
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
        public IEnumerable<int>? Movies { get; set; }
    }
}