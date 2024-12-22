namespace FinanceTrackerAPI.Web.APIs
{
    public static class TransactionAPIs
    {
        public static IEndpointRouteBuilder MapTransactionAPIs(this IEndpointRouteBuilder app)
        {
            var transactions = app.MapGroup("/transactions")
                .WithTags("Transactions")
                .WithDescription("APIs for managing transactions.");

            transactions.MapGet("/", () => "Hello world")
                .WithName("GetAllTransactions")
                .WithSummary("Get all transactions")
                .WithDescription("Retrieves the details of all transactions");

            transactions.MapGet("/{id}", () => "Hello world")
                .WithName("GetTransactionById")
                .WithSummary("Get a transaction")
                .WithDescription("Retrieves the details of a particualar transaction");

            transactions.MapPost("/", () => "Hello world")
                .WithName("CreateTransaction")
                .WithSummary("Create a transaction")
                .WithDescription("Creates a new transaction");

            transactions.MapPut("/{id}", () => "Hello world")
                .WithName("UpdateTransaction")
                .WithSummary("Update a transaction")
                .WithDescription("Updates one or more of the fields of a transaction");

            transactions.MapDelete("/{id}", () => "Hello world")
                .WithName("DeleteTransaction")
                .WithSummary("Delete a transaction")
                .WithDescription("Deletes a transaction");
            
            return app;
        }
    }
}
