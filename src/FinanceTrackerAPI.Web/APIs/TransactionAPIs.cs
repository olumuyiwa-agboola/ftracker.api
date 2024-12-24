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

            transactions.MapGet("/", async (ITransactionsService service) =>
            {
                var result = await service.GetAllTransactions();

                return result.IsSuccess switch
                {
                    true => Results.Ok(result.Value),
                    false => Results.Problem(statusCode: result.Problem!.Status, title: result.Problem.Title)
                };

            }).WithName("GetAllTransactions")
            .WithSummary("Get all transactions")
            .WithDescription("Retrieves the details of all transactions")
            .Produces<ProblemDetails>((int)HttpStatusCode.InternalServerError)
            .Produces<List<Transaction>>((int)HttpStatusCode.OK);

            transactions.MapGet("/{id}", async ([FromRoute] string id, ITransactionsService service) =>
            {
                var result = await service.GetTransaction(id);

                return result.IsSuccess switch
                {
                    true => Results.Ok(result.Value),
                    false => Results.Problem(statusCode: result.Problem!.Status, title: result.Problem.Title)
                };

            }).WithName("GetTransactionById")
            .WithSummary("Get a transaction")
            .WithDescription("Retrieves the details of a particualar transaction")
            .Produces<ProblemDetails>((int)HttpStatusCode.InternalServerError)
            .Produces<ProblemDetails>((int)HttpStatusCode.NotFound)
            .Produces<Transaction>((int)HttpStatusCode.OK);

            transactions.MapPost("/", async ([FromBody] CreateTransactionRequest request, ITransactionsService service) =>
            {
                var result = await service.CreateTransaction(request);

                return result.IsSuccess switch
                {
                    true => Results.Ok(result.Value),
                    false => Results.Problem(statusCode: result.Problem!.Status, title: result.Problem.Title)
                };

            }).WithName("CreateTransaction")
            .WithSummary("Create a transaction")
            .WithDescription("Creates a new transaction")
            .Produces<ProblemDetails>((int)HttpStatusCode.UnprocessableEntity)
            .Produces<CreateTransactionResponse>((int)HttpStatusCode.OK);

            transactions.MapPut("/{id}", async ([FromRoute] string id, UpdateTransactionRequest request, ITransactionsService service) =>
            {
                var result = await service.UpdateTransaction(request);

                return result.IsSuccess switch
                {
                    true => Results.Ok(result.Value),
                    false => Results.Problem(statusCode: result.Problem!.Status, title: result.Problem.Title)
                };

            }).WithName("UpdateTransaction")
            .WithSummary("Update a transaction")
            .WithDescription("Updates one or more of the fields of a transaction");

            transactions.MapDelete("/{id}", async ([FromRoute] string id, ITransactionsService service) =>
            {
                var result = await service.DeleteTransaction(id);

                return result.IsSuccess switch
                {
                    true => Results.Ok(result.Value),
                    false => Results.Problem(statusCode: result.Problem!.Status, title: result.Problem.Title)
                };

            }).WithName("DeleteTransaction")
            .WithSummary("Delete a transaction")
            .WithDescription("Deletes a transaction");

            return app;
        }
    }
}