using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;
using MasiniApi.Models;

namespace MasiniApi.Cars.Models
{
    [Table("Cars")]
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; }

        [Required]
        [Column("Model")]
        public string Model { get; set; }

        [Required]
        [Column("Brand")]
        public string Brand { get; set; }

        [Required]
        [Column("Year")]
        public int Year { get; set; }

        [Required]
        [Column("Color")]
        public string Color { get; set; }

    }
}
