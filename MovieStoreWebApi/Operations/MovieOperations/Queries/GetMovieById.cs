using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Entites;

namespace MovieStoreWebApi.Operations.Queries
{
    public class GetMovieById
    {
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;
        public int id{get;set;}
        public GetMovieById(IMovieStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetMovieByIdModel Handle()
        {
            var movie = _context.Movies.Include(x => x.GenreName).Include(x => x.DirectorName).Include(x => x.Actors).Where(x=> x.ID==id).SingleOrDefault();
            if(movie is null)
            {throw new InvalidOperationException("Bu id'ye kayıtlı bir film yok");}
            
            GetMovieByIdModel vm = _mapper.Map<GetMovieByIdModel>(movie);
            return vm;
        }
//MODELLERDEKİ STRİNGLER DEĞİŞMELİ SANIRIM!!!!!!!!!!!
        
    }

    public class GetMovieByIdModel
    {
        public string? MovieTitle { get; set; }
        public string? ReleaseDate { get; set; }
        public float Price { get; set; }
        public string? Genre { get; set; }
        public string? Directors { get; set; }
        public ICollection<string>? Actors { get; set; }
    }
}