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

namespace OnlineBank.Controllers
{
    [RequireHttps]
    public class AccountTypesController : Controller
    {
        private IAccountTypeRepository accountTypeRepository;

        public AccountTypesController(IAccountTypeRepository accountTypeRepository)
        {
            this.accountTypeRepository = accountTypeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<AccountTypeViewModel> model = accountTypeRepository.GetAllAccountTypes().Select(s => new AccountTypeViewModel
            {
                accTypeId = s.accTypeId,
                accTypeName = $"{s.accTypeName}"
            });
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult AddEditAccountType(long? id)
        {
            AccountTypeViewModel model = new AccountTypeViewModel();
            if (id.HasValue)
            {
                AccountType accountType = accountTypeRepository.GetAccountType(id.Value); if (accountType != null)
                {
                    model.accTypeId = accountType.accTypeId;
                    model.accTypeName = accountType.accTypeName;
                }
            }
            return PartialView("~/Views/AccountTypes/_AddEditAccountType.cshtml", model);
        }
        [HttpPost]
        public ActionResult AddEditAccountType(long? id, AccountTypeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    AccountType accountType = isNew ? new AccountType
                    {
                        //AddedDate = DateTime.UtcNow
                    } : accountTypeRepository.GetAccountType(id.Value);
                    accountType.accTypeName = model.accTypeName;
                    if (isNew)
                    {
                        accountTypeRepository.SaveAccountType(accountType);
                    }
                    else
                    {
                        accountTypeRepository.UpdateAccountType(accountType);
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
        public IActionResult DeleteAccountType(long id)
        {
            AccountType accountType = accountTypeRepository.GetAccountType(id);
            AccountTypeViewModel model = new AccountTypeViewModel
            {
                accTypeName = $"{accountType.accTypeName}"
            };
            return PartialView("~/Views/AccountTypes/_DeleteAccountType.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteAccountType(long id, IFormCollection form)
        {
            accountTypeRepository.DeleteAccountType(id);
            return RedirectToAction("Index");
        }
    }
}

