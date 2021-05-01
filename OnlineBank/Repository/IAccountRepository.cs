using OnlineBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBank
{
    public interface IAccountRepository
    {
        void SaveAccount(Account account);
        IEnumerable<Account> GetAllAccounts();
        Account GetAccount(long id);
        void DeleteAccount(long id);
        void UpdateAccount(Account account);
    }
}
