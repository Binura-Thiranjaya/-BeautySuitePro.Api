using System;
using System.ComponentModel.DataAnnotations;

namespace BeautySuitePro.Api.Models
{
    public class Refund : BaseEntity
    {
        [Required]
        public Guid PaymentId { get; set; }

        public Guid? BookingId { get; set; }
        public Guid? GiftCardId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(500)]
        public string Reason { get; set; }

        [Required]
        [RegularExpression("full|partial")]
        public string Type { get; set; }

        [Required]
        [RegularExpression("original-method|gift-card|bank-transfer")]
        public string Method { get; set; }

        [Required]
        [RegularExpression("pending|approved|processed|rejected")]
        public string Status { get; set; } = "pending";

        [Required]
        public Guid RequestedBy { get; set; }

        [Required]
        [StringLength(100)]
        public string RequestedByName { get; set; }

        public DateTime RequestedAt { get; set; } = DateTime.UtcNow;

        public Guid? ProcessedBy { get; set; }

        [StringLength(100)]
        public string ProcessedByName { get; set; }

        public DateTime? ProcessedAt { get; set; }

        [StringLength(500)]
        public string ProcessingNotes { get; set; }

        // NAVIGATION PROPERTIES
        public Payment? Payment { get; set; }
        public Booking? Booking { get; set; }
        public GiftCard? GiftCard { get; set; }
        public User? RequestedByUser { get; set; }
        public User? ProcessedByUser { get; set; }

    }
}