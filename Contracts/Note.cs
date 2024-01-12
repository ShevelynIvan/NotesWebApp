using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Contracts
{
    public class Note
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(1), MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(1000)]
        [DisplayName("Description")]
        public string? Value { get; set; }

        [Range(0, 10, ErrorMessage = "Priority must be beetween 0 and 10 only!!")]
        public int Priority { get; set; }
    }
}
