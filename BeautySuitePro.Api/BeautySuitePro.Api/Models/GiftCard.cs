using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeautySuitePro.Api.Models
{
    public class GiftCard : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal InitialAmount { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal RemainingAmount { get; set; }

        [Required]
        [StringLength(3)]
        public string Currency { get; set; }

        public DateTime ExpiryDate { get; set; }

        [Required]
        [RegularExpression("active|redeemed|expired|cancelled")]
        public string Status { get; set; } = "active";

        public ICollection<GiftCardTransaction> Transactions { get; set; }
    }
}