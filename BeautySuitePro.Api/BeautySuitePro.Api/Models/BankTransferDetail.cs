using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeautySuitePro.Api.Models
{
    public class BankTransferDetail : BaseEntity
    {
        [Required]
        public Guid PaymentId { get; set; }

        [Required]
        public string BankName { get; set; }

        [Required]
        public string AccountNumber { get; set; }

        public string ReferenceNumber { get; set; }

        [ForeignKey("PaymentId")]
        public Payment Payment { get; set; }
    }
}