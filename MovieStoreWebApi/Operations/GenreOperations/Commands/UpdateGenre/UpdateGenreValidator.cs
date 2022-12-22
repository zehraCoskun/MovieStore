using FluentValidation;

namespace MovieStoreWebApi.Operations.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreValidator : AbstractValidator<UpdateGenre>
    {
        public UpdateGenreValidator()
        {
            RuleFor(command=> command.id).NotEmpty().GreaterThan(0);
            RuleFor(command=> command.Model.GenreName).NotEmpty();
        }
    }
}