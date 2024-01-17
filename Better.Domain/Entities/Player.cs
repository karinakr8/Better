using System.ComponentModel.DataAnnotations;

namespace Better.Domain.Entities
{
    public class Player
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public float Balance { get; set; }
    }
}
