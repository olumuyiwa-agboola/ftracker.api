using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinanceTrackerAPI.Core.Models
{
    public record CreateTransactionRequest(DateOnly Date, double Amount, string Description, TransactionType Type, TransactionCategory Category)
    {
        [Description("The day the transaction happened")]
        public DateOnly Date { get; set; } = Date;

        [Description("The amount involved in the transaction")]
        public double Amount { get; set; } = Amount;

        [MaxLength(20)]
        [RegularExpression("^[a-zA-Z]+$")]
        [Description("A description of the transaction")]
        public string Description { get; set; } = Description;

        [Description("The type of the transaction")]
        public TransactionType Type { get; set; } = Type;

        [Description("The category of the transaction")]
        public TransactionCategory Category { get; set; } = Category;
    }
}
