using System.ComponentModel;

namespace FinanceTrackerAPI.Core.Models
{
    public record Transaction
    {
        public Transaction() {}

        public Transaction(CreateTransactionRequest request)
        {
            Date = request.Date;
            Amount = request.Amount;
            Description = request.Description;
            Type = Enum.GetName(request.Type)!;
            Category = Enum.GetName(request.Category)!;
            Id = string.Concat(Enum.GetName(request.Type)!.AsSpan(0, 1), new Random().Next(1000, 10000).ToString());
        }

        public Transaction(UpdateTransactionRequest request)
        {
            Id = request.Id;
            Date = request.Date;
            Amount = request.Amount;
            Description = request.Description;
            Type = Enum.GetName(request.Type)!;
            Category = Enum.GetName(request.Category)!;
        }

        [Description("The unique identifier of the transaction, assigned by the system when the transaction is created")]
        public string? Id { get; set; }

        [Description("The day the transaction happened")]
        public string? Date { get; set; }

        [Description("The amount involved in the transaction")]
        public double Amount { get; set; }

        [Description("A description of the transaction")]
        public string? Description { get; set; }

        [Description("The type of the transaction")]
        public string? Type { get; set; }

        [Description("The category of the transaction")]
        public string? Category { get; set; }
    }
}
