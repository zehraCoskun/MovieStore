using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Entites;

namespace MovieStoreWebApi.DBOperations
{
    public class DataGenerator

    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDBContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDBContext>>()))
            {
                if (context.Actors.Any())
                { return; }
                context.Actors.AddRange
                (
                    new Actor { Firstname = "Ekin", Surname = "Koç", Movies = context.Movies.Where(x => new[] { 1 }.Contains(x.ID)).ToList() },
                    new Actor { Firstname = "Öykü", Surname = "Karayel", Movies = context.Movies.Where(x => new[] { 2 }.Contains(x.ID)).ToList() },
                    new Actor { Firstname = "Doğu", Surname = "Demirkol", Movies = context.Movies.Where(x => new[] { 3}.Contains(x.ID)).ToList() },
                    new Actor { Firstname = "Demet", Surname = "Akbağ", Movies = context.Movies.Where(x => new[] { 4,5 }.Contains(x.ID)).ToList() },
                    new Actor { Firstname = "Selahattin", Surname = "Paşalı" , Movies = context.Movies.Where(x => new[] { 1 }.Contains(x.ID)).ToList()}
                );
                context.SaveChanges();

                if (context.Directors.Any())
                { return; }
                context.Directors.AddRange
                (
                    new Director { Firstname = "Pelin", Surname = "Esmer"/*,MovieID=2*/},
                    new Director { Firstname = "Nuri Bilge", Surname = "Ceylan"/*,MovieID=3*/},
                    new Director { Firstname = "Emin", Surname = "Alper"/*,MovieID=1*/},
                    new Director { Firstname = "Ezel", Surname = "Akay"/*,MovieID=4*/},
                    new Director { Firstname = "Yusuf", Surname = "Pirhasan" }
                );
                context.SaveChanges();

                if (context.Genres.Any())
                { return; }
                context.Genres.AddRange
                (
                    new Genre { GenreName = "Drama", IsActive = true },
                    new Genre { GenreName = "Gerilim", IsActive = true },
                    new Genre { GenreName = "Komedi", IsActive = true }
                );
                context.SaveChanges();

                if (context.Movies.Any())
                { return; }
                context.Movies.AddRange
                (
                    new Movie
                    {
                        MovieTitle = "Kurak Günler",
                        ReleaseDate = new DateTime(2022, 12, 09),
                        Price = 12,
                        GenreID = 2,
                        DirectorID = 3,
                        Actors = context.Actors.Where(x => new[] { 1, 5 }.Contains(x.ID)).ToList()
                    },
                    new Movie
                    {
                        MovieTitle = "İşe Yarar Bir Şey",
                        ReleaseDate = new DateTime(2017, 04, 12),
                        Price = 8,
                        GenreID = 1,
                        DirectorID = 1,
                        Actors = context.Actors.Where(x => new[] { 2 }.Contains(x.ID)).ToList()
                    },
                    new Movie
                    {
                        MovieTitle = "Ahlat Ağacı",
                        ReleaseDate = new DateTime(2018, 06, 01),
                        Price = 14,
                        GenreID = 1,
                        DirectorID = 2,
                        Actors = context.Actors.Where(x => new[] { 3 }.Contains(x.ID)).ToList()
                    },
                    new Movie
                    {
                        MovieTitle = "Neredesin Firuze",
                        ReleaseDate = new DateTime(2004, 02, 20),
                        Price = 4,
                        GenreID = 3,
                        DirectorID = 4,
                        Actors = context.Actors.Where(x => new[] { 4 }.Contains(x.ID)).ToList()
                    },
                    new Movie
                    {
                        MovieTitle = "Kurtuluş Son Durak",
                        ReleaseDate = new DateTime(2012, 01, 06),
                        Price = 3,
                        GenreID = 3,
                        DirectorID = 5,
                        Actors = context.Actors.Where(x => new[] { 4 }.Contains(x.ID)).ToList()
                    }
                );
                context.SaveChanges();
            }


        }
    }
}