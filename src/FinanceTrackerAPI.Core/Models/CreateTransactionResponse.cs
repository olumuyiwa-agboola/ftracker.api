﻿using System.ComponentModel;

namespace FinanceTrackerAPI.Core.Models
{
    public record CreateTransactionResponse
    {
        public CreateTransactionResponse()
        {
            Message = "Transaction created successfully!";
        }

        [Description("API response message")]
        public string Message { get; init; }
    }
}