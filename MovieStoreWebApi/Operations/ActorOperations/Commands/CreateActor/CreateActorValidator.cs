using FluentValidation;

namespace MovieStoreWebApi.Operations.ActorOperations.Commands.CreateActor
{
    public class CreateActorValidator : AbstractValidator<CreateActor>
    {
        public CreateActorValidator()
        {
            RuleFor(command=> command.Model.Firstname).NotEmpty();
            RuleFor(command=> command.Model.Surname).NotEmpty();
        }
    }
}