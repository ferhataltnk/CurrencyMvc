using Business.Services.Abstract;
using Core.Utilities.Results;
using Entities;
using Newtonsoft.Json;
using Serilog;
using System.Text;

namespace Business.Services.Concrete
{
    public class CurrencyManager : ICurrencyService
    {
        private readonly ILogger _logger;
        private readonly IHttpClientFactory _httpClientFactory;
 
        public CurrencyManager(ILogger logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public Result<List<Currency>> GetCurrenciesBetweenDates(CurrencyFormModel formModel)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient()) //IHttpClientFactory
                {
                    var stringBuilder = new StringBuilder();
                    //log serilog
                    //https://localhost:44332/api CONSTANT 
                    var request = httpClient.GetAsync($"https://localhost:44332/v1/api/currencies?StartDate={formModel.StartDate}&EndDate={formModel.EndDate}&PageNumber={formModel.PageNumber}&PageSize={formModel.PageSize}");
                    var response = request.Result.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<CurrencyResult>(response);
             

                    _logger.Information(result.Message);
                    return new Result<List<Currency>>(data: result.Data, success: result.Success, message: result.Message);
                }
            }
            catch (Exception exception)
            {
                _logger.Error($"Döviz kurları getirilirken beklenmedik bir hata oluştu.\n Detay:{exception.Message}");
                return new Result<List<Currency>>(data: new List<Currency>(), success: false, message: $"Döviz kurları getirilirken beklenmedik bir hata oluştu.{Environment.NewLine} Detay:{exception.Message}");
            }
        }

        public Result<List<Currency>> GetCurrenciesByCodeAndBetweenDates(CurrencyFormModel formModel)
        {
            try
            {
               
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var stringBuilder = new StringBuilder();
                    var request = httpClient.GetAsync($"https://localhost:44332/v1/api/currencies?CurrencyCode={formModel.CurrencyCode}&StartDate={formModel.StartDate}&EndDate={formModel.EndDate}&PageNumber={formModel.PageNumber}&PageSize={formModel.PageSize}");
                    var response = request.Result.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<CurrencyResult>(response);
               

                    _logger.Information($"Döviz kurları başarıyla getirildi.{Environment.NewLine}Detay:{result.Message}");
                    return new Result<List<Currency>>(data: result.Data, success: result.Success, message: result.Message);
                }


            }
            catch (Exception exception)
            {
                _logger.Error($"Döviz kurları getirilirken beklenmedik bir hata oluştu.{Environment.NewLine} Detay:{exception.Message}");
                return new Result<List<Currency>>(data: new List<Currency>(), success: false, message: $"Döviz kurları getirilirken beklenmedik bir hata oluştu.{Environment.NewLine} Detay:{exception.Message}");
            }
        }

        public Result<List<Currency>> GetCurrenciesByCode(CurrencyFormModel formModel)
        {
            try
            {
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var stringBuilder = new StringBuilder();
                    var request = httpClient.GetAsync($"https://localhost:44332/v1/api/currencies?CurrencyCode={formModel.CurrencyCode}");
                    var response = request.Result.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<CurrencyResult>(response);
                    
                   

                    _logger.Information(result.Message);
                    return new Result<List<Currency>>(data: result.Data, success: result.Success, message: result.Message);
                }
            }
            catch (Exception exception)
            {
                _logger.Error($"Döviz kurları getirilirken beklenmedik bir hata oluştu.{Environment.NewLine} Detay:{exception.Message}");
                return new Result<List<Currency>>(data: new List<Currency>(), success: false, message: $"Döviz kurları getirilirken beklenmedik bir hata oluştu.{Environment.NewLine} Detay:{exception.Message}");
            }
        }
    }
}
