using System.Text.Json.Serialization;

namespace Pacioli.Core.Models
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
