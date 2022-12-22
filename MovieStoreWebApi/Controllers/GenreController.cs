using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;

        public GenreController(IMapper mapper, IMovieStoreDBContext context)
        {
            _mapper = mapper;
            _context = context;
        }
    }
}