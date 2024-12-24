using FinanceTrackerAPI.Core.Models;
using FinanceTrackerAPI.Core.Result;

namespace FinanceTrackerAPI.Core.Abstractions.IServices
{
    public interface ITransactionsService
    {
        Task<Result<List<Transaction>?>> GetAllTransactions();

        Task<Result<DeleteTransactionResponse>> DeleteTransaction(string transactionId);

        Task<Result<UpdateTransactionResponse>> UpdateTransaction(UpdateTransactionRequest request);

        Task<Result<Transaction?>> GetTransaction(string transactionId);

        Task<Result<CreateTransactionResponse>> CreateTransaction(CreateTransactionRequest request);
    }
}