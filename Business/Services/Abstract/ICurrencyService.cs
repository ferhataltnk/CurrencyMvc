using Core.Utilities.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstract
{
    public interface ICurrencyService
    {
        public Result<List<Currency>> GetCurrenciesByCode(CurrencyFormModel formModel);
        public Result<List<Currency>> GetCurrenciesBetweenDates(CurrencyFormModel formModel);
        public Result<List<Currency>> GetCurrenciesByCodeAndBetweenDates(CurrencyFormModel formModel);
    }
}
