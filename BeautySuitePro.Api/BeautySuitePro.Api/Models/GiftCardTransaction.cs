using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySuitePro.Api.Models
{
    public class GiftCardTransaction : BaseEntity
    {
        [Required]
        public Guid GiftCardId { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        [RegularExpression("credit|debit")]
        public string Type { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        [ForeignKey("GiftCardId")]
        public GiftCard GiftCard { get; set; }
    }
}