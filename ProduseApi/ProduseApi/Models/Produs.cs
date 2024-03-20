using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProduseApi.Models
{
    [Table("produse")]
    public class Produs
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("data_expirari")]
        public DateTime Expirare { get; set; }
        [Required]

        [Column("pret")]
        public int Pret {  get; set; }



    }
}
