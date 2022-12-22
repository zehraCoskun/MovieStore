using FluentValidation;

namespace MovieStoreWebApi.Operations.GenreOperations.Commands
{
    public class CreateGenreValidator : AbstractValidator<CreateGenre>
    {
        public CreateGenreValidator()
        {
            RuleFor(command=> command.Model.GenreName).NotEmpty();
        }
    }
}