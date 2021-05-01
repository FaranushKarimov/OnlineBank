using OnlineBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBank
{
    public interface IBankBranchRepository
    {
        void SaveBankBranch(BankBranch bankBranch);
        IEnumerable<BankBranch> GetAllBankBranches();
        BankBranch GetBankBranch(long id);
        void DeleteBankBranch(long id);
        void UpdateBankBranch(BankBranch bankBranch);
    }
}
