using System.ComponentModel.DataAnnotations;

namespace SatbayevUsers.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [StringLength(12)]
        [RegularExpression(@"^\d{12}$")]
        public string IIN { get; set; } = null!;
    }
}
