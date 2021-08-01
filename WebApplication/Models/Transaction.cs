using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace OracleMvcTemplate.Models
{
    [Table("Transaction")]
    public partial class Transaction
    {
        public string AccountNumber { get; set; }
        public string BeneficiaryName { get; set; }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }
        public int Amount { get; set; }
        public DateTime? TransactionDate { get; set; }
        public int TransactionId { get; set; }
    }
}
