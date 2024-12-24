using System.Net;
using Microsoft.AspNetCore.Mvc;
using FinanceTrackerAPI.Core.Models;
using FinanceTrackerAPI.Core.Abstractions.IServices;

namespace FinanceTrackerAPI.Web.APIs
{
    public static class TransactionAPIs
    {
        public static IEndpointRouteBuilder MapTransactionAPIs(this IEndpointRouteBuilder app)
        {
            var transactions = app.MapGroup("api/transactions")
                .WithTags("Transactions")
                .WithDescription("APIs for managing transactions.");

            transactions.MapGet("/", async (ITransactionsService service) => HandleResult(await service.GetAllTransactions()))
                .WithName("GetAllTransactions")
                .WithSummary("Get all transactions")
                .WithDescription("Retrieves the details of all transactions")
                .Produces<ProblemDetails>((int)HttpStatusCode.InternalServerError)
                .Produces<List<Transaction>>((int)HttpStatusCode.OK);

            transactions.MapGet("/{id}", async ([FromRoute] string id, ITransactionsService service) => HandleResult(await service.GetTransaction(id)))
                .WithName("GetTransactionById")
                .WithSummary("Get a transaction")
                .WithDescription("Retrieves the details of a particualar transaction")
                .Produces<ProblemDetails>((int)HttpStatusCode.InternalServerError)
                .Produces<ProblemDetails>((int)HttpStatusCode.NotFound)
                .Produces<Transaction>((int)HttpStatusCode.OK);

            transactions.MapPost("/", async ([FromBody] CreateTransactionRequest request, ITransactionsService service) => HandleResult(await service.CreateTransaction(request)))
                .WithName("CreateTransaction")
                .WithSummary("Create a transaction")
                .WithDescription("Creates a new transaction")
                .Produces<ProblemDetails>((int)HttpStatusCode.UnprocessableEntity)
                .Produces<CreateTransactionResponse>((int)HttpStatusCode.OK);

            transactions.MapPut("/{id}", async ([FromRoute] string id, UpdateTransactionRequest request, ITransactionsService service) => HandleResult(await service.UpdateTransaction(request)))
                .WithName("UpdateTransaction")
                .WithSummary("Update a transaction")
                .WithDescription("Updates one or more of the fields of a transaction");

            transactions.MapDelete("/{id}", async ([FromRoute] string id, ITransactionsService service) => HandleResult(await service.DeleteTransaction(id)))
                .WithName("DeleteTransaction")
                .WithSummary("Delete a transaction")
                .WithDescription("Deletes a transaction");

            return app;
        }

        private static IResult HandleResult<TResult>(TResult result) where TResult : Core.Result.IResult
        {
            return result.IsSuccess switch
            {
                true => Results.Ok(result.GetValue()),
                false => Results.Problem(statusCode: result.Problem!.Status, title: result.Problem.Title)
            };
        }
    }
}