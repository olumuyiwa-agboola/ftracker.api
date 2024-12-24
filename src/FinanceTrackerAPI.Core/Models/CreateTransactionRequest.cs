using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinanceTrackerAPI.Core.Models
{
    public record CreateTransactionRequest(string Date, float Amount, string Description, TransactionType Type, TransactionCategory Category)
    {
        [Description("The day the transaction happened")]
        public string Date { get; init; } = Date;

        [Description("The amount involved in the transaction")]
        public float Amount { get; init; } = Amount;

        [Description("The type of the transaction")]
        public TransactionType Type { get; init; } = Type;

        [MaxLength(20)]
        [RegularExpression("^[a-zA-Z]+$")]
        [Description("A description of the transaction")]
        public string Description { get; init; } = Description;

        [Description("The category of the transaction")]
        public TransactionCategory Category { get; init; } = Category;
    }
}
