using System.ComponentModel.DataAnnotations;

namespace BeautySuitePro.Api.Models
{
    public class Service : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal PriceLKR { get; set; }

        [Required]
        [Range(5, 600)]
        public int DurationMinutes { get; set; }

        public string Description { get; set; }
    }
}