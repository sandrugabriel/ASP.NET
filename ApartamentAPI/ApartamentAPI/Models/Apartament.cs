using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApartamentAPI.Models
{

    [Table("apartaments")]
    public class Apartament
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Required]

        [Column("numberRooms")]
        public int Room { get; set; }
        [Required]

        [Column("address")]
        public string Address { get; set; }
        [Required]

        [Column("price")]
        public int Price { get; set; }


    }
}
