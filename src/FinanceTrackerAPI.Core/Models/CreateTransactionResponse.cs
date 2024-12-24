using System.ComponentModel;

namespace FinanceTrackerAPI.Core.Models
{
    public record CreateTransactionResponse
    {
        public CreateTransactionResponse(Transaction transaction)
        {
            TransactionDetails = transaction;
            Message = "Transaction created successfully!";
        }

        [Description("API response message")]
        public string Message { get; init; }

        [Description("Details of the newly created transaction")]
        public Transaction TransactionDetails { get; init; }
    }
}