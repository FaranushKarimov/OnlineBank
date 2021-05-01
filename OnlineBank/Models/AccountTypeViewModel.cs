using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OnlineBank.Models;

namespace OnlineBank.Models
{
    public class AccountTypeViewModel
    {
        public int accTypeId { get; set; }
        [Display(Name = "Account Type Name")]
        public string accTypeName { get; set; }
    }
}
