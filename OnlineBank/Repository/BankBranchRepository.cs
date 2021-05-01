using Microsoft.EntityFrameworkCore;
using OnlineBank.Context;
using OnlineBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBank.Repository
{
    public class BankBranchRepository : IBankBranchRepository
    {
        private OnlineBankContext context;
        private DbSet<BankBranch> bankBranchEntity;

        public BankBranchRepository(OnlineBankContext context)
        {
            this.context = context;
            bankBranchEntity = context.Set<BankBranch>();
        }


        public void SaveBankBranch(BankBranch bankBranch)
        {
            context.Entry(bankBranch).State = EntityState.Added;
            context.SaveChanges();
        }

        public IEnumerable<BankBranch> GetAllBankBranches()
        {
            return bankBranchEntity.AsEnumerable();
        }

        public BankBranch GetBankBranch(long id)
        {
            return bankBranchEntity.SingleOrDefault(s => s.bankId == id);
        }
        public void DeleteBankBranch(long id)
        {
            BankBranch bankBranch = GetBankBranch(id);
            bankBranchEntity.Remove(bankBranch);
            context.SaveChanges();
        }
        public void UpdateBankBranch(BankBranch bankBranch)
        {
            context.SaveChanges();
        }

    }
}
