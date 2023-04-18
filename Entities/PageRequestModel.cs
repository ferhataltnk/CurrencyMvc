using System.Text.Json.Serialization;

namespace Entities
{
    public class PageRequestModel
    {
        [JsonPropertyName("pageNumber")]
        public int? PageNumber { get; set; }

        [JsonPropertyName("pageSize")]
        public int? PageSize { get; set; }
    }
}