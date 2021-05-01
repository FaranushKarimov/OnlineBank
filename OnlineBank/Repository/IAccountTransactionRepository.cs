using OnlineBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBank
{
    public interface IAccountTransactionRepository
    {
        void SaveAccountTransaction(AccountTransaction accountTransaction);
        IEnumerable<AccountTransaction> GetAllAccountTransactions();
        AccountTransaction GetAccountTransaction(long id);
        void DeleteAccountTransaction(long id);
        void UpdateAccountTransaction(AccountTransaction accountTransaction);
    }
}
