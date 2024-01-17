using System.ComponentModel.DataAnnotations;

namespace Better.Domain.Entities
{
    public class Entity
    {
        private static int nextId = 1;
        [Key]
        [Required]
        public int Id { get; set; } = nextId++;
        protected virtual object Actual => this;
        public override bool Equals(object? obj)
        {
            if (obj is not Entity other) return false;
            if (ReferenceEquals(this, other)) return true;
            if (Actual.GetType() != other.Actual.GetType()) return false;
            if (Id == default || other.Id == default) return false;
            return Id == other.Id;
        }
        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null & b is null) return true;
            if (a is null || b is null) return false;
            return a.Equals(b);

        }
        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }
        public override int GetHashCode()
        {
            return (Actual.GetType().ToString() + Id).GetHashCode();
        }
    }
}
