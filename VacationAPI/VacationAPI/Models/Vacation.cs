using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VacationAPI.Models
{
    [Table("vacations")]
    public class Vacation
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Required]

        [Column("destination")]
        public string Destination { get; set; }
        [Required]

        [Column("duration")]
        public int duration { get; set; }
        [Required]

        [Column("price")]
        public int Price { get; set; }


    }
}
