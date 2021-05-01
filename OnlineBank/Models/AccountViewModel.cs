using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OnlineBank.Models;

namespace OnlineBank.Models
{
    public class AccountViewModel
    {
        public int accountId { get; set; }
        [Display(Name = "Account Number")]
        public string accountNumber { get; set; }
        [Display(Name =  "Name")]
        public string name { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Username")]
        public string username { get; set; }
        [Display(Name = "Phone number")]
        public string phone { get; set; }
        [Display(Name = "City")]
        public string city { get; set; }
        [Display(Name = "Limit")]
        public float limit { get; set; }
        [Display(Name = "Balance")]
        public float balance { get; set; }
        [Display(Name = "Expiry Date")]
        public DateTime expDate { get; set; }
        [Display(Name = "Bank ID")]
        public int bankId { get; set; }
        [Display(Name = "Account Type ID")]
        public int accTypeId { get; set; }
    }
}
