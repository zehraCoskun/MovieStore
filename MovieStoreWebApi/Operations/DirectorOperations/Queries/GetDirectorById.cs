using AutoMapper;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Operations.DirectorOperations.Queries
{
    public class GetDirectorById
    {
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;
        public int id { get; set; }

        public GetDirectorById(IMovieStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetDirectorByIdModel Handle()
        {
            var director =_context.Directors.Where(x=> x.ID==id).SingleOrDefault();
            if (director is null)
            { throw new InvalidOperationException("Bu id'ye kayıtlı bir yönetmen yok"); }

            GetDirectorByIdModel vm = _mapper.Map<GetDirectorByIdModel>(director);
            return vm;
        }
    }

    public class GetDirectorByIdModel
    {
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
    }
}