using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BankAccountAPI.Models
{

    [Table("bank")]
    public class BankAccount
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Required]

        [Column("balance")]
        public int Balance { get; set; }
        [Required]

        [Column("type")]
        public string Type { get; set; }
        [Required]

        [Column("ownerName")]
        public string Name { get; set; }


    }
}
