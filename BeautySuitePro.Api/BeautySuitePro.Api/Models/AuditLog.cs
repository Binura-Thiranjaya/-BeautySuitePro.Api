using System;
using System.ComponentModel.DataAnnotations;

namespace BeautySuitePro.Api.Models
{
    public class AuditLog : BaseEntity
    {
        [Required]
        public Guid? UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string Action { get; set; }

        [Required]
        [StringLength(100)]
        public string EntityName { get; set; }

        public Guid? EntityId { get; set; }

        [StringLength(2000)]
        public string Changes { get; set; }

        [StringLength(100)]
        public string IpAddress { get; set; }
    }
}