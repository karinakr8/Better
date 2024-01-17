using System.ComponentModel.DataAnnotations;

namespace Better.Domain.Entities
{
    public class Event
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public bool IsLive { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public List<Odd>? Odds { get; set; }
    }
}