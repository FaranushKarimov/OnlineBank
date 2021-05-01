using Microsoft.EntityFrameworkCore;
using OnlineBank.Context;
using OnlineBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBank.Repository
{
    public class AccountTypeRepository : IAccountTypeRepository
    {
        private OnlineBankContext context;
        private DbSet<AccountType> accountTypeEntity;

        public AccountTypeRepository(OnlineBankContext context)
        {
            this.context = context;
            accountTypeEntity = context.Set<AccountType>();
        }


        public void SaveAccountType(AccountType accountType)
        {
            context.Entry(accountType).State = EntityState.Added;
            context.SaveChanges();
        }

        public IEnumerable<AccountType> GetAllAccountTypes()
        {
            return accountTypeEntity.AsEnumerable();
        }

        public AccountType GetAccountType(long id)
        {
            return accountTypeEntity.SingleOrDefault(s => s.accTypeId == id);
        }
        public void DeleteAccountType(long id)
        {
            AccountType accountType = GetAccountType(id);
            accountTypeEntity.Remove(accountType);
            context.SaveChanges();
        }
        public void UpdateAccountType(AccountType accountType)
        {
            context.SaveChanges();
        }

    }
}
