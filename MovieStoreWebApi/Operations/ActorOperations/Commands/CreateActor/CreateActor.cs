using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entites;

namespace MovieStoreWebApi.Operations.ActorOperations.Commands.CreateActor
{
    public class CreateActor
    {
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;
        public CreateActorModel Model { get; set; }
        public CreateActor(IMapper mapper, IMovieStoreDBContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x => x.Firstname + x.Surname == Model.Firstname + x.Surname);
            if (actor is not null)
            { throw new InvalidOperationException("Bu isme sahip bir oyuncu zaten mevcut"); }
            actor = _mapper.Map<Actor>(Model);
            _context.Actors.Add(actor);
            _context.SaveChanges();
        }
    }

    public class CreateActorModel
    {
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
        public IEnumerable<int>? Movies { get; set; }
    }
}
//filmleri ekleyemiyor, niye bilmiyorum :(