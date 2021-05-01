using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBank.Models
{
    public class Transaction
    {
        
        [Key]
        public int transId { get; set; }
        public DateTime transDate { get; set; }
        public int transAmount { get; set; }
        public string fromAccount { get; set; }
        public string toAccount { get; set; }


        public int typeId { get; set; }
        public string typeName { get; set; }
        public TransactionType TransactionType {get; set;}
        public ICollection<AccountTransaction> AccountTransactions { get; set; }
    }
}
