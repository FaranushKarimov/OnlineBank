using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OnlineBank.Models;

namespace OnlineBank.Models
{
    public class TransactionViewModel
    {
        public int transId { get; set; }
        [Display(Name = "Transaction Date")]
        public DateTime transDate { get; set; }
        [Display(Name = "Transaction Amount")]
        public int transAmount { get; set; }
        [Display(Name = "Type ID")]
        public int typeId { get; set; }
        [Display(Name = "From Account")]
        public string fromAccount { get; set; }
        [Display(Name = "To Account")]
        public string toAccount { get; set; }

        //[Display(Name = "Type Name")]
        //public string typeName { get; set; }

        //public AccountTransaction accountTransaction { get; set; }

    }
}
