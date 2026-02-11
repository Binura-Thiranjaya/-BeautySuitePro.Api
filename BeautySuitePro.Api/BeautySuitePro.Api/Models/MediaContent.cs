using System;
using System.ComponentModel.DataAnnotations;

namespace BeautySuitePro.Api.Models
{
    public class MediaContent : BaseEntity
    {
        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(500)]
        public string Url { get; set; }

        [Required]
        [RegularExpression("image|video|reel|newsletter")]
        public string MediaType { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public bool IsPublished { get; set; } = true;
    }
}