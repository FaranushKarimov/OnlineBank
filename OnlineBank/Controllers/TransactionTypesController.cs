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
    public class TransactionTypesController : Controller
    {
        private ITransactionTypeRepository transactionTypeRepository;

        public TransactionTypesController(ITransactionTypeRepository transactionTypeRepository)
        {
            this.transactionTypeRepository = transactionTypeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<TransactionTypeViewModel> model = transactionTypeRepository.GetAllTransactionTypes().Select(s => new TransactionTypeViewModel
            {
                typeId = s.typeId,
                typeName = $"{s.typeName}"
            });
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult AddEditTransactionType(long? id)
        {
            TransactionTypeViewModel model = new TransactionTypeViewModel();
            if (id.HasValue)
            {
                TransactionType transactionType = transactionTypeRepository.GetTransactionType(id.Value); if (transactionType != null)
                {
                    model.typeId = transactionType.typeId;
                    model.typeName = transactionType.typeName;
                }
            }
            return PartialView("~/Views/TransactionTypes/_AddEditTransactionType.cshtml", model);
        }
        [HttpPost]
        public ActionResult AddEditTransactionType(long? id, TransactionTypeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    TransactionType transactionType = isNew ? new TransactionType
                    {
                        //AddedDate = DateTime.UtcNow
                    } : transactionTypeRepository.GetTransactionType(id.Value);
                    transactionType.typeName = model.typeName;
                    if (isNew)
                    {
                        transactionTypeRepository.SaveTransactionType(transactionType);
                    }
                    else
                    {
                        transactionTypeRepository.UpdateTransactionType(transactionType);
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
        public IActionResult DeleteTransactionType(long id)
        {
            TransactionType transactionType = transactionTypeRepository.GetTransactionType(id);
            TransactionTypeViewModel model = new TransactionTypeViewModel
            {
                typeName = $"{transactionType.typeName}"
            };
            return PartialView("~/Views/TransactionTypes/_DeleteTransactionType.cshtml", model);
        }
        [HttpPost]
        public IActionResult DeleteTransactionType(long id, IFormCollection form)
        {
            transactionTypeRepository.DeleteTransactionType(id);
            return RedirectToAction("Index");
        }
    }
}
