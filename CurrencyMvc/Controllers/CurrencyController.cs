
using Business.Services.Abstract;
using CurrencyMvc.Filters;
using CurrencyMvc.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CurrencyMvc.Controllers
{
    [ServiceFilter(typeof(ExceptionFilter))]
    public class CurrencyController : Controller
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }
      
        public IActionResult Index(CurrencyFormModel formModel)
        {
            CurrencyCodes dovizler = new CurrencyCodes();
            ViewBag.Dovizler = dovizler;

            CurrencyFormModel formModel1= new CurrencyFormModel();
            formModel1 = formModel;
            return View(formModel1);
            
        }
        public IActionResult Error(string errorMessage = null)
        {
            var model = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                ErrorMessage = errorMessage
            };

            return View(model);
        }
    }
}
