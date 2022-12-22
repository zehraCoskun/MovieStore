using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Operations.MovieOperations.Commands.CreateMovie;
using MovieStoreWebApi.Operations.MovieOperations.Commands.DeleteMovie;
using MovieStoreWebApi.Operations.MovieOperations.Commands.UpdateMovie;
using MovieStoreWebApi.Operations.Queries;

namespace MovieStoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;

        public MovieController(IMovieStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetMovies()
        {
            GetMovies query = new GetMovies(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            GetMovieById query = new GetMovieById(_context,_mapper);
            GetMovieByIdModel result;
            query.id=id;

            GetMovieByIdValidator validator = new GetMovieByIdValidator();
            validator.ValidateAndThrow(query);
            result=query.Handle();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie (int id)
        {
            DeleteMovie command = new DeleteMovie(_context);
            command.id=id;
            DeleteMovieValidator validator = new DeleteMovieValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateMovie (int id, [FromBody] UpdateMovieModel updatedModel)
        {
            UpdateMovie command = new UpdateMovie(_context);
            command.id=id;
            command.Model=updatedModel;
            UpdateMovieValidator validator = new UpdateMovieValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPost]
        public IActionResult CreateMovie([FromBody] CreateMovieModel newModel)
        {
            CreateMovie command = new CreateMovie(_context,_mapper);
            command.Model = newModel;
            CreateMovieValidator validator = new CreateMovieValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}