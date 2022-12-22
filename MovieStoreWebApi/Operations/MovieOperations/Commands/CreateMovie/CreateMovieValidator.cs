using FluentValidation;

namespace MovieStoreWebApi.Operations.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieValidator : AbstractValidator<CreateMovie>
    {
        public CreateMovieValidator()
        {
            RuleFor(command=> command.Model.ActorID).NotEmpty().GreaterThan(0);
            RuleFor(command=> command.Model.GenreID).NotEmpty().GreaterThan(0);
            RuleFor(command=> command.Model.DirectorID).NotEmpty().GreaterThan(0);
            RuleFor(command=> command.Model.MovieTitle).NotEmpty();
            RuleFor(command=> command.Model.ReleaseDate.Date).NotEmpty().GreaterThan(DateTime.Now.Date);
            
        }
    }
}