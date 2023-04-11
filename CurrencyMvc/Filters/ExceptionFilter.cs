using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace CurrencyMvc.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, $"Beklenmedik bir hata oluştu.Detay: {context.Exception}.", context.ActionDescriptor.DisplayName);

                context.Result = new RedirectToActionResult("Error", "Currency", new { errorMessage = context.Exception.Message });

                context.ExceptionHandled = true;
            
            
        }
    }
}
