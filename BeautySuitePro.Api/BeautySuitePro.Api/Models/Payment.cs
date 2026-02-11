using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeautySuitePro.Api.Models
{
    public class Payment : BaseEntity
    {
        [Required]
        public Guid BookingId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(3)]
        public string Currency { get; set; }

        public decimal AmountLKR { get; set; }

        [Required]
        [RegularExpression("pending|completed|failed|refunded")]
        public string Status { get; set; } = "pending";

        public ICollection<PaymentMethod> PaymentMethods { get; set; }
        public ICollection<BankTransferDetail> BankTransferDetails { get; set; }
        public ICollection<Refund> Refunds { get; set; }
    }
}