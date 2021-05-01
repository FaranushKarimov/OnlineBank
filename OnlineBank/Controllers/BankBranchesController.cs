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
    public class BankBranchesController : Controller
    {
        private IBankBranchRepository bankBranchRepository;

        public BankBranchesController(IBankBranchRepository bankBranchRepository)
        {
            this.bankBranchRepository = bankBranchRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<BankBranchViewModel> model = bankBranchRepository.GetAllBankBranches().Select(s => new BankBranchViewModel
            {
                bankId = s.bankId,
                bankName = $"{s.bankName}",
                bankLocation = $"{s.bankLocation}"
            });
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult AddEditBankBranch(long? id)
        {
            BankBranchViewModel model = new BankBranchViewModel();
            if (id.HasValue)
            {
                BankBranch bankBranch = bankBranchRepository.GetBankBranch(id.Value); if (bankBranch != null)
                {
                    model.bankId = bankBranch.bankId;
                    model.bankName = bankBranch.bankName;
                    model.bankLocation = bankBranch.bankLocation;
                }
            }
            return PartialView("~/Views/BankBranches/_AddEditBankBranch.cshtml", model);
        }
        [HttpPost]
        public ActionResult AddEditBankBranch(long? id, BankBranchViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    BankBranch bankBranch = isNew ? new BankBranch
                    {
                        //AddedDate = DateTime.UtcNow
                    } : bankBranchRepository.GetBankBranch(id.Value);
                    bankBranch.bankName = model.bankName;
                    bankBranch.bankLocation = model.bankLocation;
                    if (isNew)
                    {
                        bankBranchRepository.SaveBankBranch(bankBranch);
                    }
                    else
                    {
                        bankBranchRepository.UpdateBankBranch(bankBranch);
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
        public IActionResult DeleteBankBranch(long id)
        {
            BankBranch bankBranch = bankBranchRepository.GetBankBranch(id);
            BankBranchViewModel model = new BankBranchViewModel
            {
                bankName = $"{bankBranch.bankName}"
            };
            return PartialView("~/Views/BankBranches/_DeleteBankBranch.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteBankBranch(long id, IFormCollection form)
        {
            bankBranchRepository.DeleteBankBranch(id);
            return RedirectToAction("Index");
        }
    }
}


