using System.ComponentModel.DataAnnotations;

namespace Better.Domain.Entities
{
    public class Player : Entity
    {
        [Required]
        public float Balance { get; set; }
    }
}
