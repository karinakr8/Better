using System.ComponentModel.DataAnnotations;

namespace Better.Domain.Entities
{
    public class Odd
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public float Value { get; set; }
    }
}
