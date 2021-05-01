using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineBank.Context;
using OnlineBank.Models;

namespace OnlineBank.Controllers
{
    [RequireHttps]
    public class TransactionsController : Controller
    {
        private ITransactionRepository transactionRepository;

        public TransactionsController(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<TransactionViewModel> model = transactionRepository.GetAllTransactions().Select(s => new TransactionViewModel
            {
                transId = s.transId,
                transDate = s.transDate,
                transAmount = s.transAmount,
                fromAccount = $"{s.fromAccount}",
                toAccount = $"{s.toAccount}",
                typeId = s.typeId
            });
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Admin()
        {
            IEnumerable<TransactionViewModel> model = transactionRepository.GetAllTransactions().Select(s => new TransactionViewModel
            {
                transId = s.transId,
                transDate = s.transDate,
                transAmount = s.transAmount,
                fromAccount = $"{s.fromAccount}",
                toAccount = $"{s.toAccount}",
                typeId = s.typeId
            });
            return View("Admin", model);
        }



        [HttpGet]
        public IActionResult AddEditTransaction(long? id)
        {
            TransactionViewModel model = new TransactionViewModel();
            if (id.HasValue)
            {
                Transaction transaction = transactionRepository.GetTransaction(id.Value); if (transaction != null)
                {
                    model.transId = transaction.transId;
                    model.transDate = transaction.transDate;
                    model.transAmount = transaction.transAmount;
                    model.fromAccount = transaction.fromAccount;
                    model.toAccount = transaction.toAccount;
                    model.typeId = transaction.typeId;
                }
            }
            return View("~/Views/Transactions/_AddEditTransaction.cshtml", model);
        }
        [HttpPost]
        public ActionResult AddEditTransaction(long? id, TransactionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Transaction transaction = isNew ? new Transaction
                    {
                        //AddedDate = DateTime.UtcNow
                    } : transactionRepository.GetTransaction(id.Value);
                    transaction.transDate = model.transDate;
                    transaction.transAmount = model.transAmount;
                    transaction.fromAccount = model.fromAccount;
                    transaction.toAccount = model.toAccount;
                    transaction.typeId = model.typeId;
                
                    if (isNew)
                    {
                        transactionRepository.SaveTransaction(transaction);
                    }
                    else
                    {
                        transactionRepository.UpdateTransaction(transaction);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteTransaction(long id)
        {
            Transaction transaction = transactionRepository.GetTransaction(id);
            TransactionViewModel model = new TransactionViewModel
            {
                transDate = transaction.transDate,
                transAmount = transaction.transAmount,
                fromAccount = transaction.fromAccount,
                toAccount = transaction.toAccount,
                typeId = transaction.typeId
            };
            return PartialView("~/Views/Transactions/_DeleteTransaction.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteTransaction(long id, IFormCollection form)
        {
            transactionRepository.DeleteTransaction(id);
            return RedirectToAction("Index");
        }



        public IActionResult TransactionHistory()
        {
            IEnumerable<TransactionViewModel> model = transactionRepository.GetAllTransactions().Select(s => new TransactionViewModel
            {
                transId = s.transId,
                transDate = s.transDate,
                transAmount = s.transAmount,
                fromAccount = s.fromAccount,
                toAccount = s.toAccount,
                typeId = s.typeId
            });
            return View("TransactionHistory", model);
        }

        //public IActionResult Transfer(Transaction trans)
        //{
        //    Transaction transaction = transactionRepository.SaveTransaction(trans);
        //    TransactionViewModel model = new TransactionViewModel
        //    {
        //        transDate = transaction.transDate,
        //        transAmount = transaction.transAmount,
        //        typeName = transaction.typeName
        //    };
        //    return PartialView("~/Views/Transactions/_DeleteTransaction.cshtml", model);
        //}

        [HttpGet]
        public IActionResult Transfer(long id)
        {
            Transaction transaction = transactionRepository.GetTransaction(id);
            TransactionViewModel model = new TransactionViewModel
            {
                transDate = transaction.transDate,
                transAmount = transaction.transAmount,
                fromAccount = transaction.fromAccount,
                toAccount = transaction.toAccount,
                typeId = transaction.typeId
            };

            transactionRepository.SaveTransaction(model);

            return View("Transfer");
        }

        [HttpGet]
        public IActionResult Loan(long? id)
        {
            TransactionViewModel model = new TransactionViewModel();
            if (id.HasValue)
            {
                Transaction transaction = transactionRepository.GetTransaction(id.Value); if (transaction != null)
                {
                    model.transId = transaction.transId;
                    model.transDate = transaction.transDate;
                    model.transAmount = transaction.transAmount;
                    model.toAccount = transaction.toAccount;
                    model.typeId = transaction.typeId;
                }
            }
            return View("~/Views/Transactions/Loan.cshtml", model);
        }
        [HttpPost]
        public ActionResult Loan(long? id, TransactionViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Transaction transaction = isNew ? new Transaction
                    {
                        //AddedDate = DateTime.UtcNow
                    } : transactionRepository.GetTransaction(id.Value);
                    transaction.transDate = model.transDate;
                    transaction.transAmount = model.transAmount;
                    transaction.toAccount = model.toAccount;
                    transaction.typeId = model.typeId;

                    if (isNew)
                    {
                        transactionRepository.SaveTransaction(transaction);
                    }
                    else
                    {
                        transactionRepository.UpdateTransaction(transaction);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ConfirmTransaction(long id)
        {
            Transaction transaction = transactionRepository.GetTransaction(id);
            TransactionViewModel model = new TransactionViewModel
            {
                transDate = transaction.transDate,
                transAmount = transaction.transAmount,
                fromAccount = transaction.fromAccount,
                toAccount = transaction.toAccount,
                typeId = transaction.typeId
            };
            return View("~/Views/Transactions/ConfirmTransaction.cshtml", model);
        }
        [HttpPost]
        public IActionResult ConfirmTransaction(long id, IFormCollection form)
        {
            transactionRepository.DeleteTransaction(id);
            return RedirectToAction("Index");
        }

    }
}
