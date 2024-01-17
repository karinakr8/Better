using System.ComponentModel.DataAnnotations;

namespace Better.Domain.Models
{
    public class BetLog
    {
        [Required]
        public int BetId { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        public int OddId { get; set; }
        [Required]
        public string? ResultCode { get; set; }
    }
}
