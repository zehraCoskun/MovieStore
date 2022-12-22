using FluentValidation;

namespace MovieStoreWebApi.Operations.Queries
{
    public class GetMovieByIdValidator : AbstractValidator<GetMovieById>
    {
        public GetMovieByIdValidator()
        {
            RuleFor(query=>query.id).GreaterThan(0).NotEmpty();
        }
    }
}