using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBank.Models
{
    public class AccountTransaction
    {
        [Key]
        public int accTransId { get; set; }

        public int accountId { get; set; }
        public int transId { get; set; }

        public Account Account {get; set;}
        public Transaction Transaction { get; set; }
    }
}
