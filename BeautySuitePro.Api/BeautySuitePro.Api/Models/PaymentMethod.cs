using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySuitePro.Api.Models
{
    public class PaymentMethod : BaseEntity
    {
        [Required]
        public Guid PaymentId { get; set; }

        [Required]
        [RegularExpression("cash|card|online|gift-card|bank-transfer")]
        public string Method { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [ForeignKey("PaymentId")]
        public Payment Payment { get; set; }
    }
}