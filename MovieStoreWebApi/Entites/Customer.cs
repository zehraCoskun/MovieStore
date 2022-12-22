using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entites
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerID { get; set; }
        public string? Firstname { get; set; }
        public string? Surname { get; set; }
        //public int GenreID { get; set; }
        //public Genre? GenreName { get; set; }

        //favori türleri eklenebilmeli
        //satın aldığı filmler eklenecek
        //birden fazla favori tür eklenebilmeli
    }
}