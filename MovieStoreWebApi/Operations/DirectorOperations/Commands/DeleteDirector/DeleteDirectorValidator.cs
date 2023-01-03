using FluentValidation;

namespace MovieStoreWebApi.Operations.DirectorOperations.Commands
{
    public class DeleteDirectorValidator : AbstractValidator<DeleteDirector>
    {
        public DeleteDirectorValidator()
        {
            RuleFor(command => command.id).NotEmpty().GreaterThan(0);
        }
    }
}