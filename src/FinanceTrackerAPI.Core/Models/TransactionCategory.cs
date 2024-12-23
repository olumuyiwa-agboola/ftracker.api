using System.Text.Json.Serialization;

namespace FinanceTrackerAPI.Core.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter<TransactionCategory>))]
    public enum TransactionCategory
    {
        FOOD,

        CLOTHING
    }
}
