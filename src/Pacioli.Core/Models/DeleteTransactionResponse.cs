using System.ComponentModel;

namespace Pacioli.Core.Models
{
    public record DeleteTransactionResponse
    {
        public DeleteTransactionResponse()
        {
            Message = "Transaction updated successfully!";
        }

        [Description("API response message")]
        public string Message { get; init; }
    }
}