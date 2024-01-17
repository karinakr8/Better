using System.ComponentModel.DataAnnotations;

namespace Better.Domain.Entities
{
    public class Event : Entity
    {
        [Required]
        public bool IsLive { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public List<Odd>? Odds { get; set; }
    }
}