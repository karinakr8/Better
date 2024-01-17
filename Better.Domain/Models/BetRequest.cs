using System.ComponentModel.DataAnnotations;

namespace Better.Domain.Models
{
    public class BetRequest
    {
        [Required]
        public int EventId { get; set; }
        [Required]
        public float Odd { get; set; }
        [Required]
        public int PlayerId { get; set; }
        [Required]
        public float Price { get; set; }
    }
}
