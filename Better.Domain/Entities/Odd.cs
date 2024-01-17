using System.ComponentModel.DataAnnotations;

namespace Better.Domain.Entities
{
    public class Odd : Entity
    {
        [Required]
        public float Value { get; set; }
    }
}
