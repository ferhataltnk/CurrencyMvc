namespace Entities
{
    public class CurrencyFormModel : PageRequestModel
    {
        public string? CurrencyCode { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
       
    }
}
