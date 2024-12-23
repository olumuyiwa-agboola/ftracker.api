using FinanceTrackerAPI.Core.Models;

namespace FinanceTrackerAPI.Core.Services
{
    public class TransactionService
    {
        public async Task<Transaction> CreateTransaction(CreateTransactionRequest request)
        {
            var (date, amount, description, type, category) = request;

            Transaction transaction = new("T0001", date, amount, description, type, category);

            return transaction;
        }
    }
}
