using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasiniApi.Models
{
    [Table("masini")]
    public class Masini
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("model")]
        public string Model { get; set; }

        [Required]
        [Column("marca")]
        public string Marca { get; set; }

        [Required]
        [Column("anul")]
        public int Year { get; set; }

        [Required]
        [Column("culoare")]
        public string Culoare {  get; set; }

    }
}
