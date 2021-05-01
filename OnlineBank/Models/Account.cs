using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBank.Models
{
    public class Account
    {
        public int accountId { get; set; }
        public String password { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public string loginStatus { get; set; }
        public float limit { get; set; }
        public float balance { get; set; }
        public DateTime expDate { get; set; }
        public string accountNumber { get; set; }

        public int bankId { get; set; }
        public int accTypeId { get; set; }

        public AccountType AccountType { get; set; }
        public BankBranch BankBranch { get; set; }
        public ICollection<AccountTransaction> AccountTransactions { get; set; }

    }
}
