using OnlineBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBank
{
    public interface ITransactionTypeRepository
    {
        void SaveTransactionType(TransactionType transactionType);
        IEnumerable<TransactionType> GetAllTransactionTypes();
        TransactionType GetTransactionType(long id);
        void DeleteTransactionType(long id);
        void UpdateTransactionType(TransactionType transactionType);
    }
}
