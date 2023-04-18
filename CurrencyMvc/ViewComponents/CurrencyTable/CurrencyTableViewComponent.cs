using Business.Services.Abstract;
using CurrencyMvc.App_Start.Filters;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyMvc.ViewComponents.CurrencyTable
{
    [ServiceFilter(typeof(ExceptionFilter))]
    public class CurrencyTableViewComponent : ViewComponent
    {
        private readonly ICurrencyService _currencyService;
        
        public CurrencyTableViewComponent(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }
        public IViewComponentResult Invoke(CurrencyFormModel formModel)
        {
            List<Currency> value = new List<Currency>();

            if (formModel.StartDate != null || formModel.EndDate != null)
            {
                if (formModel.CurrencyCode == null)
                {
                    var temp = _currencyService.GetCurrenciesBetweenDates(formModel);
                    if (temp.Success)
                        value = temp.Data;
                }
                else
                {
                    var temp = _currencyService.GetCurrenciesByCodeAndBetweenDates(formModel);
                    if (temp.Success)
                        value = temp.Data;
                }
            }
           
            else if (formModel.CurrencyCode != null)
            {
                var temp = _currencyService.GetCurrenciesByCode(formModel);
                if (temp.Success)
                    value = temp.Data;
            }

            return View(value);
        }
    }
}
