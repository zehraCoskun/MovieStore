using FluentValidation;

namespace MovieStoreWebApi.Operations.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorValidator : AbstractValidator<UpdateActor>
    {
        public UpdateActorValidator()
        {
            RuleFor(command => command.id).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.Firstname).NotEmpty();
            RuleFor(command => command.Model.Surname).NotEmpty();
        }
    }
}