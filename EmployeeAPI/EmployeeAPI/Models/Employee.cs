using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAPI.Models
{

    [Table("employees")]
    public class Employee
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Required]

        [Column("name")]
        public string Name { get; set; }
        [Required]

        [Column("departament")]
        public string Departament { get; set; }
        [Required]

        [Column("salary")]
        public int Salary { get; set; }


    }
}
