using OnlineBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBank
{
    public interface IAccountTypeRepository
    {
        void SaveAccountType(AccountType accountType);
        IEnumerable<AccountType> GetAllAccountTypes();
        AccountType GetAccountType(long id);
        void DeleteAccountType(long id);
        void UpdateAccountType(AccountType accountType);
    }
}
