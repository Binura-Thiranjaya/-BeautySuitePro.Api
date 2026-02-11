using System.ComponentModel.DataAnnotations;

namespace BeautySuitePro.Api.Models
{
    public class Currency : BaseEntity
    {
        [Required]
        [StringLength(3)]
        public string Code { get; set; } // LKR, USD, GBP

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(5)]
        public string Symbol { get; set; }

        [Required]
        [Range(0.0001, double.MaxValue)]
        public decimal ExchangeRateToLKR { get; set; }

        public bool IsBaseCurrency { get; set; } = false;
    }
}