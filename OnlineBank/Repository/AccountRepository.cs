using Microsoft.EntityFrameworkCore;
using OnlineBank.Context;
using OnlineBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBank.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private OnlineBankContext context;
        private DbSet<Account> accountEntity;

        public AccountRepository(OnlineBankContext context)
        {
            this.context = context;
            accountEntity = context.Set<Account>();
        }


        public void SaveAccount(Account account)
        {
            context.Entry(account).State = EntityState.Added;
            context.SaveChanges();
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return accountEntity.AsEnumerable();
        }

        public Account GetAccount(long id)
        {
            return accountEntity.SingleOrDefault(s => s.accountId == id);
        }
        public void DeleteAccount(long id)
        {
            Account account = GetAccount(id);
            accountEntity.Remove(account);
            context.SaveChanges();
        }
        public void UpdateAccount(Account account)
        {
            context.SaveChanges();
        }

    }
}
