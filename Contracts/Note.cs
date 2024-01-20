using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Contracts
{
    public class Note : ValidatorBase
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "No more than 50 characters")]
        public string Name { get; set; }

        [StringLength(1000, ErrorMessage = "No more than 1000 characters")]
        [DisplayName("Description")]
        public string? Value { get; set; }

        [Range(0, 10, ErrorMessage = "Priority must be beetween 0 and 10 only!!")]
        public int Priority { get; set; }
    }
}
