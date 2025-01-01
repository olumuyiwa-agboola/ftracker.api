using System.Text.Json.Serialization;

namespace Pacioli.Core.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter<TransactionCategory>))]
    public enum TransactionCategory
    {
        FOOD,

        CLOTHING
    }
}
