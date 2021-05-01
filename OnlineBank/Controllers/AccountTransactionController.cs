//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using OnlineBank.Context;
//using OnlineBank.Models;

//namespace OnlineBank.Controllers
//{
//    [RequireHttps]
//    public class AccountTransactionController : Controller
//    {
//        private readonly OnlineBankContext _context;

//        //public AccountTransactionController(OnlineBankContext context)
//        //{
//        //    _context = context;
//        //}

//        private IAccountTransactionRepository accountTransactionRepository;

//        public AccountTransactionController(IAccountTransactionRepository accountTransactionRepository)
//        {
//            this.accountTransactionRepository = accountTransactionRepository;
//        }

//        // GET: AccountTransactions
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.AccountTransactions.ToListAsync());
//        }

//        // GET: AccountTransactions/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var accountTransaction = await _context.AccountTransactions
//                .FirstOrDefaultAsync(m => m.accTransId == id);
//            if (accountTransaction == null)
//            {
//                return NotFound();
//            }

//            return View(accountTransaction);
//        }

//        // GET: AccountTransactions/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: AccountTransactions/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("accTransId,accountId,transId")] AccountTransaction accountTransaction)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(accountTransaction);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(accountTransaction);
//        }

//        // GET: AccountTransactions/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var accountTransaction = await _context.AccountTransactions.FindAsync(id);
//            if (accountTransaction == null)
//            {
//                return NotFound();
//            }
//            return View(accountTransaction);
//        }

//        // POST: AccountTransactions/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("accTransId,accountId,transId")] AccountTransaction accountTransaction)
//        {
//            if (id != accountTransaction.accTransId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(accountTransaction);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!AccountTransactionExists(accountTransaction.accTransId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(accountTransaction);
//        }

//        // GET: AccountTransactions/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var accountTransaction = await _context.AccountTransactions
//                .FirstOrDefaultAsync(m => m.accTransId == id);
//            if (accountTransaction == null)
//            {
//                return NotFound();
//            }

//            return View(accountTransaction);
//        }

//        // POST: AccountTransactions/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var accountTransaction = await _context.AccountTransactions.FindAsync(id);
//            _context.AccountTransactions.Remove(accountTransaction);
//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool AccountTransactionExists(int id)
//        {
//            return _context.AccountTransactions.Any(e => e.accTransId == id);
//        }

//        public IActionResult Deposit()
//        {

//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Deposit(AccountTransaction accountTransaction)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.AccountTransactions.Add(accountTransaction);
//                _context.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            //ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", item.CategoryId);

//            return View(accountTransaction);
//        }

//        public IActionResult Transfer()
//        {
//            return View();
//        }

//        public IActionResult Types()
//        {
//            return View();
//        }


//        //////
//        ///
//        [HttpGet]
//        public IActionResult AddEditAccountTransaction(long? id)
//        {
//            TransactionViewModel model = new TransactionViewModel();
//            if (id.HasValue)
//            {
//                AccountTransaction transaction = accountTransactionRepository.GetAccountTransaction(id.Value);
//                if (transaction != null)
//                {
//                    model.accountTransaction.accTransId = transaction.accTransId;
//                    model.accountTransaction.accountId = transaction.accountId;
//                    model.transId = transaction.transId;
//                    model.accountTransaction.Account.email = transaction.Account.email;
//                    model.accountTransaction.Account.name = transaction.Account.name;
//                    model.accountTransaction.Transaction.transAmount = transaction.Transaction.transAmount;
//                }
//            }
//            return View("~/Views/AccountTransaction/AddEditAccountTransaction.cshtml", model);
//        }
//        [HttpPost]
//        public ActionResult AddEditAccountTransaction(long? id, TransactionViewModel model)
//        {
//            try
//            {
//                if (ModelState.IsValid)
//                {
//                    bool isNew = !id.HasValue;
//                    AccountTransaction transaction = isNew ? new AccountTransaction
//                    {
//                        //AddedDate = DateTime.UtcNow
//                    } : accountTransactionRepository.GetAccountTransaction(id.Value);
//                    transaction.Account.email = model.accountTransaction.Account.email;
//                    transaction.Account.name = model.accountTransaction.Account.name;
//                    transaction.Transaction.transAmount = model.accountTransaction.Transaction.transAmount;

//                    if (isNew)
//                    {
//                        accountTransactionRepository.SaveAccountTransaction(transaction);
//                    }
//                    else
//                    {
//                        accountTransactionRepository.UpdateAccountTransaction(transaction);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            return RedirectToAction("Index");
//        }
//    }
//}
