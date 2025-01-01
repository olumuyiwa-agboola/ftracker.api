﻿using System.ComponentModel;

namespace Pacioli.Core.Models
{
    public record UpdateTransactionResponse
    {
        public UpdateTransactionResponse()
        {
            Message = "Transaction updated successfully!";
        }

        [Description("API response message")]
        public string Message { get; init; }
    }
}