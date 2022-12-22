using FluentValidation;

namespace MovieStoreWebApi.Operations.GenreOperations.Queries
{
    public class GetGenresByIdValidator : AbstractValidator<GetGenresById>
    {
        public GetGenresByIdValidator()
        {
            RuleFor(query => query.id).NotEmpty().GreaterThan(0);
        }
    }
}