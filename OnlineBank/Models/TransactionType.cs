using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBank.Models
{
    public class TransactionType
    {
        [Key]
        public int typeId { get; set; }
        public String typeName { get; set; }


        public ICollection<Transaction> Transactions { get; set; }
    }
}
