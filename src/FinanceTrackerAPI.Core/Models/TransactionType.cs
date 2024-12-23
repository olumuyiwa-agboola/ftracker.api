using System.Text.Json.Serialization;

namespace FinanceTrackerAPI.Core.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter<TransactionType>))]
    public enum TransactionType
    {
        INCOME,

        SAVING,

        INVESTMENT,

        EXPENDITURE
    }
}
