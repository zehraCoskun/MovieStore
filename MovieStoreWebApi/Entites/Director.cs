using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entites
{
    public class Director
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
       /* public int MovieID { get; set; }
        public Movie? MovieName { get; set; }*/
    }
}