using AutoMapper;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entites;

namespace MovieStoreWebApi.Operations.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirector
    {
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;
        public DirectorCreateModel Model { get; set; }
        public CreateDirector(IMovieStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(x => x.Firstname + x.Surname == Model.Firstname + x.Surname);
            if (director is not null)
            { throw new InvalidOperationException("Bu isme sahip bir yönetmen zaten mevcut"); }
            director = _mapper.Map<Director>(Model);
            _context.Directors.Add(director);
            _context.SaveChanges();
        }
    }

    public class DirectorCreateModel
    {
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
    }
}