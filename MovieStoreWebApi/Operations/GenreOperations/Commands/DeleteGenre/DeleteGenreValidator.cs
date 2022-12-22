using FluentValidation;
using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Operations.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreValidator : AbstractValidator<DeleteGenre>
    {
        public DeleteGenreValidator()
        {
            RuleFor(command => command.id).NotEmpty().GreaterThan(0);
        }
    }
}