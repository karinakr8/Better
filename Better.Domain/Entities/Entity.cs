using System.ComponentModel.DataAnnotations;

namespace Better.Domain.Entities
{
    public class Entity
    {
        [Key]
        [Required]
        public int Id { get; set; }
    }
}
