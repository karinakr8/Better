using Better.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Better.Domain.Entities
{
    public class Bet
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public Event? Event { get; set; }
        [Required]
        public Odd? Odd { get; set; }
        [Required]
        public Player? Player { get; set; }
        [Required]
        public string? Result { get; set; }
    }
}