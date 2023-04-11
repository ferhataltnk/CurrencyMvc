using Business.Services.Abstract;
using Core.Utilities.Results;
using Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Business.Services.Concrete
{
    public class CurrencyManager : ICurrencyService
    {
        private readonly ILogger<CurrencyManager> _logger;

        public CurrencyManager(ILogger<CurrencyManager> logger)
        {
            _logger = logger;
        }

        public Result<List<Currency>> GetAllCurrencyBetweenTwoDate(CurrencyFormModel formModel)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var request = httpClient.GetAsync($"https://localhost:44332/api/Currency/v1/currency/{formModel.StartDate.ToString()}&{formModel.EndDate.ToString()}");
                    var response2 = request.Result.Content.ReadAsStringAsync().Result;
                    var value = JsonConvert.DeserializeObject<List<Currency>>(response2);

                    _logger.LogInformation("Döviz kurları başarıyla getirildi.");
                    return new Result<List<Currency>>(data: value, success: true, message: "Döviz kurları başarıyla getirildi.");
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Döviz kurları getirilirken beklenmedik bir hata oluştu.\n Detay:{e.Message}");
                return new Result<List<Currency>>(data: new List<Currency>(), success: false, message: $"Döviz kurları getirilirken beklenmedik bir hata oluştu.\n Detay:{e.Message}");
            }
        }

        public Result<List<Currency>> GetCurrenciesBetweenTwoDateAndWithCode(CurrencyFormModel formModel)
        {
            try
            {   
                using (var httpClient = new HttpClient())
                {
                    var request = httpClient.GetAsync($"https://localhost:44332/api/Currency/v1/currency/{formModel.CurrencyCode.ToString()}/{formModel.StartDate.ToString()}&{formModel.EndDate.ToString()}");
                    var response3 = request.Result.Content.ReadAsStringAsync().Result;
                    var value = JsonConvert.DeserializeObject<List<Currency>>(response3);
                    _logger.LogInformation("Döviz kurları başarıyla getirildi.");
                    return new Result<List<Currency>>(data: value, success: true, message: "Döviz kurları başarıyla getirildi.");
                }    
               

            }
            catch (Exception e)
            {
                _logger.LogError($"Döviz kurları getirilirken beklenmedik bir hata oluştu.\n Detay:{e.Message}");
                return new Result<List<Currency>>(data: new List<Currency>(), success: false, message: $"Döviz kurları getirilirken beklenmedik bir hata oluştu.\n Detay:{e.Message}");
            }
        }

        public Result<List<Currency>> GetCurrenciesByCode(CurrencyFormModel formModel)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var request = httpClient.GetAsync($"https://localhost:44332/api/Currency/v1/currency/{formModel.CurrencyCode}");
                    var response2 = request.Result.Content.ReadAsStringAsync().Result;
                    var temp = JsonConvert.DeserializeObject<Currency>(response2);
                    var value = new List<Currency>();
                    value.Add(temp);
                    //var c=value.SingleOrDefault<Currency>(p => p.CurrencyCode == formModel.CurrencyCode);
                    //if(c is not null)
                    _logger.LogInformation("Döviz kurları başarıyla getirildi.");
                    return new Result<List<Currency>>(data: value, success: true, message: "Döviz kurları başarıyla getirildi.");
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Döviz kurları getirilirken beklenmedik bir hata oluştu.\n Detay:{e.Message}");
                return new Result<List<Currency>>(data:new List<Currency>(),success:false,message:$"Döviz kurları getirilirken beklenmedik bir hata oluştu.\n Detay:{e.Message}");
            }

      
        }

      
    }
}
