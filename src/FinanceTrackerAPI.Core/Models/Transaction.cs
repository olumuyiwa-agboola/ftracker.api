using System.ComponentModel;

namespace FinanceTrackerAPI.Core.Models
{
    public record Transaction(string Id, DateOnly Date, double Amount, string Description, TransactionType Type, TransactionCategory Category)
    {
        [Description("The unique identifier of the transaction, assigned by the system when the transaction is created")]
        public string Id { get; set; } = Id;

        [Description("The day the transaction happened")]
        public DateOnly Date { get; set; } = Date;

        [Description("The amount involved in the transaction")]
        public double Amount { get; set; } = Amount;

        [Description("A description of the transaction")]
        public string Description { get; set; } = Description;

        [Description("The type of the transaction")]
        public TransactionType Type { get; set; } = Type;

        [Description("The category of the transaction")]
        public TransactionCategory Category { get; set; } = Category;
    }
}
