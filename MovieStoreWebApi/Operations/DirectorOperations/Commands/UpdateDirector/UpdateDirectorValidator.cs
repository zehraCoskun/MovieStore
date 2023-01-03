using FluentValidation;

namespace MovieStoreWebApi.Operations.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorValidator : AbstractValidator<UpdateDirector>
    {
        public UpdateDirectorValidator()
        {
            RuleFor(command=> command.id).GreaterThan(0).NotEmpty();
            RuleFor(command=> command.Model.Firstname).NotEmpty();
            RuleFor(command=> command.Model.Surname).NotEmpty();
        }
    }
}