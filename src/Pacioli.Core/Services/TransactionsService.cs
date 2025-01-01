using Pacioli.Core.Models;
using Pacioli.Core.Result;
using Pacioli.Core.Abstractions.IServices;
using Pacioli.Core.Abstractions.IRepositories;

namespace Pacioli.Core.Services
{
    public class TransactionsService(ITransactionsRepository transactionsRepository) : ITransactionsService
    {
        public async Task<Result<CreateTransactionResponse>> CreateTransaction(CreateTransactionRequest request)
        {
            Transaction transaction = new(request);

            int result = await transactionsRepository.AddTransaction(transaction);

            if (result == 1)
                return new CreateTransactionResponse();
            else
                return Error.UnprocessableEntity();
        }

        public async Task<Result<DeleteTransactionResponse>> DeleteTransaction(string transactionId)
        {
            int result = await transactionsRepository.DeleteTransaction(transactionId);

            if (result == 1)
                return new DeleteTransactionResponse();
            else
                return Error.UnprocessableEntity();
        }

        public async Task<Result<List<Transaction>?>> GetAllTransactions()
        {
            List<Transaction>? transactions = await transactionsRepository.GetAllTransactions();

            if (transactions is not null && transactions.Count != 0)
                return transactions;
            else
                return Error.UnprocessableEntity();
        }

        public async Task<Result<Transaction?>> GetTransaction(string transactionId)
        {
            Transaction? transaction = await transactionsRepository.GetTransaction(transactionId);

            if (transaction is not null)
                return transaction;
            else
                return Error.NotFound("Transaction not found");
        }

        public async Task<Result<UpdateTransactionResponse>> UpdateTransaction(UpdateTransactionRequest request)
        {
            Transaction transaction = new(request);

            int result = await transactionsRepository.UpdateTransaction(transaction);

            if (result == 1)
                return new UpdateTransactionResponse();
            else
                return Error.UnprocessableEntity();
        }
    }
}