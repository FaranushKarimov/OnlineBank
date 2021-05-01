using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBank.Models
{
    public class BankBranch
    {
        [Key]
        public int bankId { get; set; }
        public String bankName { get; set; }
        public String bankLocation { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
