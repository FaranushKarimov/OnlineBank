using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OnlineBank.Models;

namespace OnlineBank.Models
{
    public class BankBranchViewModel
    {
        public int bankId { get; set; }
        [Display(Name = "Bank Name")]
        public string bankName { get; set; }
        [Display(Name = "Bank Location")]
        public string bankLocation { get; set; }
    }
}
