using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [RegularExpression("full|partial", ErrorMessage = "Invalid refund type.")]
        public string Type { get; set; }

        [Required]
        [RegularExpression("original-method|gift-card|bank-transfer", ErrorMessage = "Invalid refund method.")]
        public string Method { get; set; }

        [Required]
        [RegularExpression("pending|approved|processed|rejected", ErrorMessage = "Invalid status.")]
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

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        [ForeignKey("PaymentId")]
        public Payment Payment { get; set; }

        [ForeignKey("BookingId")]
        public Booking Booking { get; set; }

        [ForeignKey("GiftCardId")]
        public GiftCard GiftCard { get; set; }

        [ForeignKey("RequestedBy")]
        public User RequestedByUser { get; set; }

        [ForeignKey("ProcessedBy")]
        public User ProcessedByUser { get; set; }
    }
}
