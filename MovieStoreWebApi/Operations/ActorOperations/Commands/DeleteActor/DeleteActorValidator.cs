using FluentValidation;

namespace MovieStoreWebApi.Operations.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorValidator : AbstractValidator<DeleteActor>
    {
        public DeleteActorValidator()
        {
            RuleFor(command => command.id).GreaterThan(0).NotEmpty();
        }
    }
}