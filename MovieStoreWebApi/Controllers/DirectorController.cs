using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Operations.DirectorOperations.Commands.CreateDirector;
using MovieStoreWebApi.Operations.DirectorOperations.Commands.UpdateDirector;
using MovieStoreWebApi.Operations.DirectorOperations.Commands;
using MovieStoreWebApi.Operations.DirectorOperations.Queries;

namespace MovieStoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class DirectorController : ControllerBase
    {
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;

        public DirectorController(IMovieStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetDirectors()
        {
            GetDirectors query = new GetDirectors(_mapper, _context);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetDirectorById(int id)
        {
            GetDirectorById query = new GetDirectorById(_context, _mapper);
            query.id = id;
            GetDirectorByIdModel result;
            GetDirectorByIdValidator validator = new GetDirectorByIdValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDirector(int id)
        {
            DeleteDirector command = new DeleteDirector(_context);
            command.id=id;
            DeleteDirectorValidator validator = new DeleteDirectorValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateDirector(int id, [FromBody] DirectorUpdateModel Model)
        {
            UpdateDirector command = new UpdateDirector(_context);
            command.id=id;
            command.Model=Model;
            UpdateDirectorValidator validator = new UpdateDirectorValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPost]
        public IActionResult CreateDirector([FromBody] DirectorCreateModel Model)
        {
            CreateDirector command = new CreateDirector(_context,_mapper);
            command.Model=Model;
            CreateDirectorValidator validator = new CreateDirectorValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}