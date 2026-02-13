using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySuitePro.Api.Models
{
    public class Booking : BaseEntity
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid ServiceId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        [RegularExpression("pending|confirmed|completed|cancelled")]
        public string Status { get; set; } = "pending";

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("ServiceId")]
        public Service Service { get; set; }

    }
}