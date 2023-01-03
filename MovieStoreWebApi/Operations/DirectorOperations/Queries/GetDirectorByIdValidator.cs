using FluentValidation;

namespace MovieStoreWebApi.Operations.DirectorOperations.Queries
{
    public class GetDirectorByIdValidator : AbstractValidator<GetDirectorById>
    {
        public GetDirectorByIdValidator()
        {
            RuleFor(query=> query.id).NotEmpty().GreaterThan(0);
        }
    }
}