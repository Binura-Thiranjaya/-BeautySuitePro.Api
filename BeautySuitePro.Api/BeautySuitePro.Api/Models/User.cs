using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeautySuitePro.Api.Models
{
    public class User : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; }

        [Required]
        [RegularExpression("admin|doctor|receptionist|technician|customer")]
        public string Role { get; set; }
        
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Refund> RequestedRefunds { get; set; }
        public ICollection<Refund> ProcessedRefunds { get; set; }
    }
}