using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySuitePro.Api.Models
{
    public class Notification : BaseEntity
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string Message { get; set; }

        public bool IsRead { get; set; } = false;

        [Required]
        [RegularExpression("booking|payment|refund|system|promotion")]
        public string Type { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}