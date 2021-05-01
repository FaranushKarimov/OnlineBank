using Microsoft.EntityFrameworkCore;
using OnlineBank.Context;
using OnlineBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBank.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private OnlineBankContext context;
        private DbSet<Transaction> transactionEntity;

        public TransactionRepository(OnlineBankContext context)
        {
            this.context = context;
            transactionEntity = context.Set<Transaction>();
        }


        public void SaveTransaction(Transaction transaction)
        {
            context.Entry(transaction).State = EntityState.Added;
            context.SaveChanges();
        }

        public void SaveTransaction(TransactionViewModel transaction)
        {
            context.Entry(transaction).State = EntityState.Added;
            context.SaveChanges();
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return transactionEntity.AsEnumerable();
        }

        public Transaction GetTransaction(long id)
        {
            return transactionEntity.SingleOrDefault(s => s.transId == id);
        }
        public void DeleteTransaction(long id)
        {
            Transaction transaction = GetTransaction(id);
            transactionEntity.Remove(transaction);
            context.SaveChanges();
        }
        public void UpdateTransaction(Transaction transaction)
        {
            context.SaveChanges();
        }

    }
}
