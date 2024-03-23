using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentApi.Models
{
    [Table("students")]
    public class Student
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id")]
        public int Id { get; set; }
        [Required]

        [Column("name")]
        public string Name { get; set; }
        [Required]

        [Column("age")]
        public int Age { get; set; }
        [Required]

        [Column("grade")]
        public int Grade { get; set; }


    }
}
