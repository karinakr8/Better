using System.ComponentModel.DataAnnotations;

namespace Better.Domain.Entities
{
    public class Entity
    {
        private static int nextId = 1;
        [Key]
        [Required]
        public int Id { get; set; } = nextId++;
    }
}
