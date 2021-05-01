using Microsoft.EntityFrameworkCore;
using OnlineBank.Context;
using OnlineBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBank.Repository
{
    public class TransactionTypeRepository : ITransactionTypeRepository
    {
        private OnlineBankContext context;
        private DbSet<TransactionType> transactionTypeEntity;

        public TransactionTypeRepository(OnlineBankContext context)
        {
            this.context = context;
            transactionTypeEntity = context.Set<TransactionType>();
        }


        public void SaveTransactionType(TransactionType transactionType)
        {
            context.Entry(transactionType).State = EntityState.Added;
            context.SaveChanges();
        }

        public IEnumerable<TransactionType> GetAllTransactionTypes()
        {
            return transactionTypeEntity.AsEnumerable();
        }

        public TransactionType GetTransactionType(long id)
        {
            return transactionTypeEntity.SingleOrDefault(s => s.typeId == id);
        }
        public void DeleteTransactionType(long id)
        {
            TransactionType transactionType = GetTransactionType(id);
            transactionTypeEntity.Remove(transactionType);
            context.SaveChanges();
        }
        public void UpdateTransactionType(TransactionType transactionType)
        {
            context.SaveChanges();
        }

    }
}
