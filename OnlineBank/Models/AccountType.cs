using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBank.Models
{
    public class AccountType
    {
        [Key]
        public int accTypeId { get; set; }
        public String accTypeName { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
