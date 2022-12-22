using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Operations.ActorOperations.Queries
{
    public class GetActorById
    {
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;
        public int id { get; set; }

        public GetActorById(IMovieStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetActorByIdModel Handle()
        {
            var actor = _context.Actors.Include(x => x.Movies).Where(x => x.ID == id).SingleOrDefault();
            if (actor is null)
            { throw new InvalidOperationException("Bu id'ye kayıtlı bir oyuncu yok"); }

            GetActorByIdModel vm = _mapper.Map<GetActorByIdModel>(actor);
            return vm;
        }
    }

    public class GetActorByIdModel
    {
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
        public ICollection<string>? Movies { get; set; }
    }
}