using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Operations.GenreOperations.Commands;
using MovieStoreWebApi.Operations.GenreOperations.Commands.DeleteGenre;
using MovieStoreWebApi.Operations.GenreOperations.Commands.UpdateGenre;
using MovieStoreWebApi.Operations.GenreOperations.Queries;

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
        [HttpGet]
        public IActionResult GetGenres()
        {
            GetGenres query = new GetGenres(_context,_mapper);
            var result = query.Handle(); 
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetGenre(int id)
        {
            GetGenresById query = new GetGenresById(_context,_mapper);
            GetGenreByIdModel result;
            query.id=id;
            GetGenresByIdValidator validator = new GetGenresByIdValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenre command = new DeleteGenre(_context);
            command.id=id;
            DeleteGenreValidator validator = new DeleteGenreValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel model)
        {
            UpdateGenre command = new UpdateGenre(_context);
            command.id=id;
            command.Model=model;
            UpdateGenreValidator validator = new UpdateGenreValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPost]
        public IActionResult CreateGenre(int id, [FromBody] CreateGenreModel model)
        {
            CreateGenre command = new CreateGenre(_mapper,_context);
            command.Model=model;
            CreateGenreValidator validator = new CreateGenreValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}