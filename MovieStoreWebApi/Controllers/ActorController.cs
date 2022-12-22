using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreWebApi.DBOperations;
using MovieStoreWebApi.Operations.ActorOperations.Commands.CreateActor;
using MovieStoreWebApi.Operations.ActorOperations.Commands.DeleteActor;
using MovieStoreWebApi.Operations.ActorOperations.Commands.UpdateActor;
using MovieStoreWebApi.Operations.ActorOperations.Queries;

namespace MovieStoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class ActorController : ControllerBase
    {
        private readonly IMovieStoreDBContext _context;
        private readonly IMapper _mapper;

        public ActorController(IMovieStoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetActors()
        {
            GetActors query = new GetActors(_mapper, _context);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetActorById(int id)
        {
            GetActorById query = new GetActorById(_context, _mapper);
            GetActorByIdModel result;
            query.id = id;
            GetActorByIdValidator validator = new GetActorByIdValidator();
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateActor([FromBody] CreateActorModel newModel)
        {
            CreateActor command = new CreateActor(_mapper, _context);
            command.Model = newModel;
            CreateActorValidator validator = new CreateActorValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteActor(int id)
        {
            DeleteActor command = new DeleteActor(_context);
            command.id = id;
            DeleteActorValidator validator = new DeleteActorValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateActor(int id, [FromBody] ActorUpdateModel newModel)
        {
            UpdateActor command = new UpdateActor(_context);
            command.Model=newModel;
            command.id = id;
            UpdateActorValidator validator = new UpdateActorValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}