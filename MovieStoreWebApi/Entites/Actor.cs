using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entites
{
    public class Actor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
        public ICollection<Movie>? Movies { get; set; }
    }
}
//birden fazla film eklenebilmeli