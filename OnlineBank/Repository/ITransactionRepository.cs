using OnlineBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBank
{
    public interface ITransactionRepository
    {
        void SaveTransaction(Transaction transaction);
        IEnumerable<Transaction> GetAllTransactions();
        Transaction GetTransaction(long id);
        void DeleteTransaction(long id);
        void UpdateTransaction(Transaction transaction);
        void SaveTransaction(TransactionViewModel model);
    }
}
