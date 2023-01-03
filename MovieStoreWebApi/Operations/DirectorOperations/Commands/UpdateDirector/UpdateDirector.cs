using MovieStoreWebApi.DBOperations;

namespace MovieStoreWebApi.Operations.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirector
    {
        private readonly IMovieStoreDBContext _context;
        public DirectorUpdateModel Model { get; set; }
        public int id { get; set; }

        public UpdateDirector(IMovieStoreDBContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(x => x.ID == id);
            if (director is null)
            { throw new InvalidOperationException("Bu id'ye kayıtlı bir yönetmen mevcut değil"); }

            director.Firstname = string.IsNullOrEmpty(Model.Firstname) != default ? director.Firstname : Model.Firstname;
            director.Surname = string.IsNullOrEmpty(Model.Surname) != default ? director.Surname : Model.Surname;
            _context.SaveChanges();
        }
    }

    public class DirectorUpdateModel
    {
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
    }
}