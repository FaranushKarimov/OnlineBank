using Microsoft.EntityFrameworkCore;
using OnlineBank.Context;
using OnlineBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBank.Repository
{
    public class AccountTransactionRepository : IAccountTransactionRepository
    {
        private OnlineBankContext context;
        private DbSet<AccountTransaction> accountTransactionEntity;

        public AccountTransactionRepository(OnlineBankContext context)
        {
            this.context = context;
            accountTransactionEntity = context.Set<AccountTransaction>();
        }


        public void SaveAccountTransaction(AccountTransaction accountTransaction)
        {
            context.Entry(accountTransaction).State = EntityState.Added;
            context.SaveChanges();
        }

        public IEnumerable<AccountTransaction> GetAllAccountTransactions()
        {
            return accountTransactionEntity.AsEnumerable();
        }

        public AccountTransaction GetAccountTransaction(long id)
        {
            return accountTransactionEntity.SingleOrDefault(s => s.accTransId == id);
        }
        public void DeleteAccountTransaction(long id)
        {
            AccountTransaction accountTransaction = GetAccountTransaction(id);
            accountTransactionEntity.Remove(accountTransaction);
            context.SaveChanges();
        }
        public void UpdateAccountTransaction(AccountTransaction accountTransaction)
        {
            context.SaveChanges();
        }

    }
}
