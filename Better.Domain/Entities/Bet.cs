using System.ComponentModel.DataAnnotations;

namespace Better.Domain.Entities
{
    public class Bet : Entity
    {        
        [Required]
        public Event? Event { get; set; }
        [Required]
        public int OddId { get; set; }
        [Required]
        public Player? Player { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public string? Result { get; set; }
    }
}