using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineBank.Context;
using OnlineBank.Models;
using OnlineBank;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Manage.Internal;

namespace OnlineBank.Controllers
{
    [RequireHttps]
    public class AccountController : Controller
    {
        private IAccountRepository accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<AccountViewModel> model = accountRepository.GetAllAccounts().Select(s => new AccountViewModel
            {
                accountId = s.accountId,
                accountNumber = s.accountNumber,
                name = $"{s.name}",
                email = s.email,
                username = s.username,
                phone = s.phone,
                city = s.city,
                limit = s.limit, 
                balance = s.balance,
                expDate = s.expDate,
                bankId = s.bankId,
                accTypeId = s.accTypeId
    });
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult AddEditAccount(long? id)
        {
            AccountViewModel model = new AccountViewModel();
            if (id.HasValue)
            {
                Account account = accountRepository.GetAccount(id.Value); if (account != null)
                {
                    model.accountId = account.accountId;
                    model.accountNumber = account.accountNumber;
                    model.name = account.name;
                    model.email = account.email;
                    model.username = account.username;
                    model.phone = account.phone;
                    model.city = account.city;
                    model.limit = account.limit;
                    model.balance = account.balance;
                    model.expDate = account.expDate;
                    model.bankId = account.bankId;
                    model.accTypeId = account.accTypeId;

                }
            }
            return PartialView("~/Views/Account/_AddEditAccount.cshtml", model);
        }
        [HttpPost]
        public ActionResult AddEditAccount(long? id, AccountViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Account account = isNew ? new Account
                    {
                        //AddedDate = DateTime.UtcNow
                    } : accountRepository.GetAccount(id.Value);
                    account.accountNumber = model.accountNumber;
                    account.name = model.name;
                    account.email = model.email;
                    account.username = model.username;
                    account.phone = model.phone;
                    account.city = model.city;
                    account.limit = model.limit;
                    account.balance = model.balance;
                    account.expDate = model.expDate;
                    account.bankId = model.bankId;
                    account.accTypeId = model.accTypeId;

                    if (isNew)
                    {
                        accountRepository.SaveAccount(account);
                    }
                    else
                    {
                        accountRepository.UpdateAccount(account);
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
        public IActionResult DeleteAccount(long id)
        {
            Account account = accountRepository.GetAccount(id);
            AccountViewModel model = new AccountViewModel
            {
                name = $"{account.name}"
            };
            return PartialView("~/Views/Account/_DeleteAccount.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteAccount(long id, IFormCollection form)
        {
            accountRepository.DeleteAccount(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Balance()
        {
            IEnumerable<AccountViewModel> model = accountRepository.GetAllAccounts().Select(s => new AccountViewModel
            {
                accountId = s.accountId,
                accountNumber = s.accountNumber,
                name = $"{s.name}",
                email = s.email,
                username = s.username,
                phone = s.phone,
                city = s.city,
                limit = s.limit,
                balance = s.balance,
                expDate = s.expDate,
                bankId = s.bankId,
                accTypeId = s.accTypeId
            });
            return View("Balance", model);
        }

        //[HttpGet]
        //public IActionResult Balance(long? id)
        //{
        //    AccountViewModel model = new AccountViewModel();
        //    if (id.HasValue)
        //    {
        //        Account account = accountRepository.GetAccount(id.Value);
        //        if (account != null)
        //        {
        //            model.accountId = account.accountId;
        //            model.name = account.name;
        //            model.email = account.email;
        //            model.username = account.username;
        //            model.phone = account.phone;
        //            model.city = account.city;
        //            model.limit = account.limit;
        //            model.balance = account.balance;
        //            model.expDate = account.expDate;
        //            model.bankId = account.bankId;
        //            model.accTypeId = account.accTypeId;

        //        }
        //    }
        //    return View("Balance", model);
        //}
    }
}