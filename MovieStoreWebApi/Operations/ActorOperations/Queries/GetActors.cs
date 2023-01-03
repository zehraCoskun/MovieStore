using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Operations.ActorOperations.Queries
{
    public class GetActors 
    {
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;

        public GetActors(IMapper mapper, IMovieStoreDBContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public List<ActorsViewModel> Handle()
        {
            var actorList = _context.Actors.Include(x=> x.Movies).OrderBy(x=> x.ID).ToList();
            List<ActorsViewModel> vm = _mapper.Map<List<ActorsViewModel>>(actorList);
            return vm;   
        }
    }

    public class ActorsViewModel
    {
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
        public ICollection<string>? Movies   { get; set; }
    }
}