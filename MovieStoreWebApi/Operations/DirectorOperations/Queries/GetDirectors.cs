using AutoMapper;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Operations.DirectorOperations.Queries
{
    public class GetDirectors
    {
        private readonly IMapper _mapper;
        private readonly IMovieStoreDBContext _context;
        public GetDirectors(IMapper mapper, IMovieStoreDBContext context)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<DirectorsViewModel> Handle()
        {
            var directorList = _context.Directors.OrderBy(x => x.ID);
            List<DirectorsViewModel> vm = _mapper.Map<List<DirectorsViewModel>>(directorList);
            return vm;
        }
    }

    public class DirectorsViewModel
    {
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
    }
}