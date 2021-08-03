using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace MvcTemplate.WebApi.Models
{
    [Table("Transaction")]
    public partial class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Column(TypeName = "nvarchar(12)")]
        [DisplayName("LabelAccountNumber")]
        [Required(ErrorMessage = "LabelFieldRequired")]
        [MaxLength(12, ErrorMessage = "Maximum 12 characters only")]
        public string AccountNumber { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("LabelBeneficiaryName")]
        [Required(ErrorMessage = "LabelFieldRequired")]
        public string BeneficiaryName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("LabelBankName")]
        [Required(ErrorMessage = "LabelFieldRequired")]
        public string BankName { get; set; }

        [Column(TypeName = "nvarchar(11)")]
        [DisplayName("LabelSwiftCode")]
        [Required(ErrorMessage = "LabelFieldRequired")]
        [MaxLength(11)]
        public string SwiftCode { get; set; }

        [DisplayName("LabelAmount")]
        [Required(ErrorMessage = "LabelFieldRequired")]
        public int Amount { get; set; }

        [DisplayName("LabelDate")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? TransactionDate { get; set; }
    }
}
