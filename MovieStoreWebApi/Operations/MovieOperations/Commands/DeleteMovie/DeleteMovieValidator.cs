using FluentValidation;

namespace MovieStoreWebApi.Operations.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieValidator : AbstractValidator<DeleteMovie>
    {
        public DeleteMovieValidator()
        {
            RuleFor(command=> command.id).NotEmpty().GreaterThan(0);
        }
    }
}