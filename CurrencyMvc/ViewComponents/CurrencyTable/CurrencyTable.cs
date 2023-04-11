using Business.Services.Abstract;
using CurrencyMvc.Filters;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyMvc.ViewComponents.CurrencyTable
{
    [ServiceFilter(typeof(ExceptionFilter))]
    public class CurrencyTable : ViewComponent
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyTable(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }
        public IViewComponentResult Invoke(CurrencyFormModel formModel)
        {
            List<Currency> value;

            if (formModel.StartDate is not null && formModel.EndDate is not null && formModel.CurrencyCode is null)
            {
                var temp = _currencyService.GetAllCurrencyBetweenTwoDate(formModel);
                value = temp.Success ? temp.Data : new List<Currency>();
            }
            else if (formModel.StartDate is not null && formModel.EndDate is not null && formModel.CurrencyCode is not null)
            {
                var temp = _currencyService.GetCurrenciesBetweenTwoDateAndWithCode(formModel);
                value = temp.Success ? temp.Data : new List<Currency>();
            }
            else if (formModel.StartDate is null && formModel.EndDate is null && formModel.CurrencyCode is not null)
            {
                var temp = _currencyService.GetCurrenciesByCode(formModel);
                value = temp.Success ? temp.Data : new List<Currency>();

            }
            else
            {
                value = new List<Currency>();
            }

            return View(value);
        }
    }
}
