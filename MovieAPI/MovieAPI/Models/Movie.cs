using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAPI.Models
{
    [Table("movie")]
    public class Movie
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Required]

        [Column("title")]
        public string Title { get; set; }
        [Required]

        [Column("releaseYear")]
        public int date { get; set; }
        [Required]

        [Column("gender")]
        public string Gender { get; set; }  


    }
}
