using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entites
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string? MovieTitle { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float Price { get; set; }
        public int GenreID { get; set; }
        public Genre? GenreName { get; set; }
        public int DirectorID { get; set; }
        public Director? DirectorName { get; set; }
        //public int ActorID { get; set; }
        public ICollection<Actor>? Actors { get; set; }
    }
}
//birden fazla actor eklenebilmeli