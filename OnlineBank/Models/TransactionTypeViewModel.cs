using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using OnlineBank.Models;

namespace OnlineBank.Models
{
    public class TransactionTypeViewModel
    {
        public int typeId { get; set; }
        [Display(Name = "Type Name")]
        public string typeName { get; set; }

    }
}
