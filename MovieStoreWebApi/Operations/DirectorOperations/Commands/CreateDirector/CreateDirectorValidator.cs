using FluentValidation;

namespace MovieStoreWebApi.Operations.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorValidator : AbstractValidator<CreateDirector>
    {
        public CreateDirectorValidator()
        {
            RuleFor(command=> command.Model.Firstname).NotEmpty();
            RuleFor(command=> command.Model.Surname).NotEmpty();
        }
    }
}