using System.ComponentModel.DataAnnotations;

namespace Better.Domain.Entities
{
    public class Bet
    {
        private static int nextId = 1;
        [Required]
        public int Id { get; } = nextId++;
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