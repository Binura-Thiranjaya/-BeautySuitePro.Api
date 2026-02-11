using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySuitePro.Api.Models
{
    public class Review : BaseEntity
    {
       
        [Required]
        public Guid UserId { get; set; }

        // MUST BE NULLABLE because we use SetNull
        public Guid? BookingId { get; set; }

        [Required]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        [StringLength(1000)]
        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("BookingId")]
        public Booking? Booking { get; set; }
    }
}