using FluentValidation;

namespace MovieStoreWebApi.Operations.ActorOperations.Queries
{
    public class GetActorByIdValidator : AbstractValidator<GetActorById>
    {
        public GetActorByIdValidator()
        {
            RuleFor(query=> query.id).NotEmpty().GreaterThan(0);
        }
    }
}