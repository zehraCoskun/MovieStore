using FluentValidation;

namespace MovieStoreWebApi.Operations.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieValidator : AbstractValidator<UpdateMovie>
    {
        public UpdateMovieValidator()
        {
            RuleFor(command=> command.id).NotEmpty().GreaterThan(0);
            RuleFor(command=> command.Model.GenreID).NotEmpty().GreaterThan(0);
            RuleFor(command=> command.Model.DirectorID).NotEmpty().GreaterThan(0);
            RuleFor(command=> command.Model.MovieTitle).NotEmpty();
            //RuleFor(command=> command.Model.ReleaseDate.Date).NotEmpty().GreaterThan(DateTime.Now.Date);
        }
    }
}