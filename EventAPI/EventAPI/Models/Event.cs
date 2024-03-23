using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventAPI.Models
{
    [Table("eventsParty")]
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Required]

        [Column("name")]
        public string Name { get; set; }
        [Required]

        [Column("locationName")]
        public string Location { get; set; }
        [Required]

        [Column("date")]
        public DateTime Date { get; set; }
        


    }
}
