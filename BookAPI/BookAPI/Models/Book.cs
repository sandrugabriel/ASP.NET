using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAPI.Models
{
    [Table("books")]
    public class Book
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id")]
        public int Id { get; set; }
        [Required]

        [Column("title")]
        public string Name { get; set; }
        [Required]

        [Column("author")]
        public string Author { get; set; }
        [Required]

        [Column("year")]
        public int Year { get; set; }

    }
}
